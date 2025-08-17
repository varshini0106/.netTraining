using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ElectricityBillingSystem
{
    public class ElectricityBoard
    {
        public static void CalculateBill(ElectricityBill ebill)
        {
            int u = ebill.UnitsConsumed;
            double total = 0;

            // 0–100 free
            if (u > 100)
            {
                // first 100 free -> nothing to add
                int remaining = u - 100;

                // 101–300 @ 1.5 (max 200 units)
                int slab = Math.Min(remaining, 200);
                total += slab * 1.5;
                remaining -= slab;

                if (remaining > 0)
                {
                    // 301–600 @ 3.5 (max 300 units)
                    slab = Math.Min(remaining, 300);
                    total += slab * 3.5;
                    remaining -= slab;
                }

                if (remaining > 0)
                {
                    // 601–1000 @ 5.5 (max 400 units)
                    slab = Math.Min(remaining, 400);
                    total += slab * 5.5;
                    remaining -= slab;
                }

                if (remaining > 0)
                {
                    // >1000 @ 7.5
                    total += remaining * 7.5;
                }
            }
            // If u <= 100 -> total stays 0

            ebill.BillAmount = total;
        }

        public static void AddBill(ElectricityBill ebill)
        {
            var db = new DBHandler();
            using (SqlConnection con = db.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
              "INSERT INTO ElectricityBill (consumer_number, consumer_name, units_consumed, bill_amount) " +
              "VALUES (@cn, @name, @units, @amt)", con))
            {
                cmd.Parameters.AddWithValue("@cn", ebill.ConsumerNumber);
                cmd.Parameters.AddWithValue("@name", ebill.ConsumerName);
                cmd.Parameters.AddWithValue("@units", ebill.UnitsConsumed);
                cmd.Parameters.AddWithValue("@amt", ebill.BillAmount);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static List<ElectricityBill> Generate_N_BillDetails(int num)
        {
            var list = new List<ElectricityBill>();
            var db = new DBHandler();
            using (SqlConnection con = db.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                "SELECT consumer_number, consumer_name, units_consumed, bill_amount FROM ElectricityBill", con))
            {
                con.Open();
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        var eb = new ElectricityBill
                        {
                            ConsumerNumber = r.GetString(0),
                            ConsumerName = r.GetString(1),
                            UnitsConsumed = r.GetInt32(2),
                            BillAmount = r.GetDouble(3)
                        };
                        list.Add(eb);
                    }
                }
            }

            // Get the last N records and preserve their original order
            return list.Skip(Math.Max(0, list.Count - num)).ToList();
        }
    }
}