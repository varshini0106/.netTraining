using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Code_Challenge_1
{
    class question2
    {
        static void Main()
        {
            string connect = "Data Source = ICS-LT-CGQZC64\\SQLEXPRESS; Initial Catalog = AssignmentDB; user id = sa; password = Karthikavarshini2004;";
            Console.Write("Enter EmpId to update salary: ");
            int empid = Convert.ToInt32(Console.ReadLine());


            using (SqlConnection conn = new SqlConnection(connect))
            {
                SqlCommand cmd = new SqlCommand("UpdateSalary", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpId", empid);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Console.WriteLine("Updated Employee Details:");
                    Console.WriteLine($"EmpId: {reader["EmpId"]}");
                    Console.WriteLine($"Name: {reader["Name"]}");
                    Console.WriteLine($"Salary: {reader["Salary"]}");
                    Console.WriteLine($"Gender: {reader["Gender"]}");
                }
                else
                {
                    Console.WriteLine("No match found");
                }

                Console.Read();
            }
        }
    }
}
