using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using RailwayReservationSystem.DataEntities;

namespace RailwayReservationSystem.Services
{
    public class RegisterService
    {
        public Customer NewCustomer { get; set; }

        public RegisterService()
        {
            NewCustomer = new Customer();
        }

        private bool IsValidPhone(string phone)
        {
            if (phone.Length != 10)
                return false;

            foreach (char c in phone)
            {
                if (!char.IsDigit(c))
                    return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            int atIndex = email.IndexOf('@');
            int dotIndex = email.LastIndexOf('.');

            // Must contain '@' and '.' in correct order
            if (atIndex < 1 || dotIndex < atIndex + 2 || dotIndex == email.Length - 1)
                return false;

            return true;
        }

        public bool Register()
        {
            Console.Write("\nEnter username: ");
            string username = Console.ReadLine().Trim();
            // Check if username already exists
            using (var con = DbConnection.GetConnection())
            {
                con.Open();
                var checkCmd = new SqlCommand("select count(1) from Customers where Username = @Username and IsDeleted = 0", con);
                checkCmd.Parameters.AddWithValue("@Username", username);
                bool exists = (int)checkCmd.ExecuteScalar() > 0;

                if (exists)
                {
                    Console.WriteLine("\nUsername already registered! Please login.\n");

                    var loginService = new LoginService();
                    Console.Write("\nEnter username or email: ");
                    var user = Console.ReadLine().Trim();
                    Console.Write("Enter password: ");
                    var pass = Console.ReadLine().Trim();
                    bool loginSuccess = loginService.UserLogin(user, pass);

                    if (loginSuccess)
                    {
                        Console.WriteLine("\nLogin successful!");
                        //redirecting to the user menu
                        var bookingService = new BookingService();
                        var cancellationService = new CancellationService();
                        var adminService = new AdminService();                        
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("\nLogin failed.");
                    }
                    return false;
                }
            }

            // Proceed with registration
            NewCustomer.Username = username;

            Console.Write("Enter full name: ");
            NewCustomer.CustomerName = Console.ReadLine().Trim();

            // Phone validation loop
            while (true)
            {
                Console.Write("Enter 10-digit phone number: ");
                var phone = Console.ReadLine().Trim();
                if (IsValidPhone(phone)) { NewCustomer.Phone = phone; break; }
                Console.WriteLine("Invalid phone number! Please enter a valid 10-digit number.");
            }

            // Email validation loop
            while (true)
            {
                Console.Write("Enter email: ");
                var email = Console.ReadLine().Trim();
                if (IsValidEmail(email)) { NewCustomer.Email = email; break; }
                Console.WriteLine("Invalid email format! Please enter a valid email.");
            }

            Console.Write("Enter password: ");
            NewCustomer.Password = Console.ReadLine().Trim();

            // Insert new customer
            using (var con = DbConnection.GetConnection())
            {
                con.Open();
                var insert = new SqlCommand(@"insert into Customers (CustomerName, Phone, Email, Username, Password, IsDeleted)
                                      values (@Name, @Phone, @Email, @Username, @Password, 0);
                                      select SCOPE_IDENTITY();", con);
                insert.Parameters.AddWithValue("@Name", NewCustomer.CustomerName);
                insert.Parameters.AddWithValue("@Phone", NewCustomer.Phone);
                insert.Parameters.AddWithValue("@Email", NewCustomer.Email);
                insert.Parameters.AddWithValue("@Username", NewCustomer.Username);
                insert.Parameters.AddWithValue("@Password", NewCustomer.Password);

                var id = insert.ExecuteScalar();
                NewCustomer.CustomerId = Convert.ToInt32(id);
            }

            Console.WriteLine("\nRegistration Successful!!");
            Console.WriteLine($"\nWelcome {NewCustomer.CustomerName}");
            return true;
        }
    }
}
