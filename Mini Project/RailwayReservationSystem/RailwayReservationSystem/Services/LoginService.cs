using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using RailwayReservationSystem.DataEntities;

namespace RailwayReservationSystem.Services
{
    public class LoginService
    {
        public Customer LoggedInCustomer { get; private set; }
        public bool IsAdmin { get; private set; }

        public bool AdminLogin(string username, string password)
        {
            using (var con = DbConnection.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("select count(*) from Admins where Username = @user and Password = @pass", con);
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@pass", password);

                int count = (int)cmd.ExecuteScalar();

                if (count == 1)
                {
                    Console.WriteLine("\nLogin successfull!");
                    return true;
                }
                else
                {
                    Console.WriteLine("\nInvalid credentials.");
                    return false;
                }
            }
        }

        public bool UserLogin(string user, string pass)
        {
            using (var con = DbConnection.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("select CustomerId,CustomerName,Phone,Email,Username,Password,IsDeleted from Customers where (Username=@u or Email=@u)", con);
                cmd.Parameters.AddWithValue("@u", user);
                using (var rdr = cmd.ExecuteReader())
                {
                    if (!rdr.Read())
                    {
                        Console.WriteLine("\nNo user found with the provided details. Please proceed with registration.");
                        return false;
                    }
                    var storedPass = rdr[5].ToString();
                    var isDeleted = Convert.ToBoolean(rdr[6]);
                    if (isDeleted)
                    {
                        Console.WriteLine("\nNo user found with the provided details. Please proceed with registration.");
                        return false;
                    }
                    if (storedPass != pass)
                    {
                        Console.WriteLine("\nInvalid username or password! Enter correct details");
                        return false;
                    }                    
                    LoggedInCustomer = new Customer
                    {
                        CustomerId = Convert.ToInt32(rdr[0]),
                        CustomerName = rdr[1].ToString(),
                        Phone = rdr[2].ToString(),
                        Email = rdr[3].ToString(),
                        Username = rdr[4].ToString(),
                        Password = storedPass,
                        IsDeleted = false
                    };
                }
            }
            return true;
        }
    }
}
