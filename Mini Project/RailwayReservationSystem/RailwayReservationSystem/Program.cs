using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RailwayReservationSystem.Services;

namespace RailwayReservationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var loginService = new LoginService();
            var registerService = new RegisterService();
            var adminService = new AdminService();
            var bookingService = new BookingService();
            var cancellationService = new CancellationService();
            Console.WriteLine("--Welcome to Railway Reservation System!!--");
            while (true)
            {
                Console.WriteLine("\n--- Main Menu ---");
                Console.WriteLine("1. Login as Admin");
                Console.WriteLine("2. Register as User");
                Console.WriteLine("3. Login as User");
                Console.WriteLine("4. Exit");
                Console.Write("\nChoose: ");
                var ch = Console.ReadLine();
                if (ch == "1")
                {
                    Console.Write("\nEnter admin username: ");
                    string username = Console.ReadLine().Trim();
                    Console.Write("Enter admin password: ");
                    string password = Console.ReadLine().Trim();
                    if (loginService.AdminLogin(username, password))
                    {
                        // admin menu
                        while (true)
                        {
                            Console.WriteLine("\n--- Admin Menu ---");
                            Console.WriteLine("1. Add New Train");
                            Console.WriteLine("2. Update Train Details");
                            Console.WriteLine("3. Delete Train (Soft)");
                            Console.WriteLine("4. View All Reservations");
                            Console.WriteLine("5. View Registered Customers");
                            Console.WriteLine("6. View All Cancellations");
                            Console.WriteLine("7. Logout to Main Menu");
                            Console.Write("\nChoose: ");
                            var a = Console.ReadLine();
                            if (a == "1") adminService.AddTrain();
                            else if (a == "2") adminService.UpdateTrain();
                            else if (a == "3") adminService.DeleteTrain(true);
                            else if (a == "4") adminService.ViewAllReservations();
                            else if (a == "5") adminService.ViewRegisteredCustomers();
                            else if (a == "6") adminService.ViewAllCancellations();
                            else if (a == "7") break;
                        }
                    }
                }
                else if (ch == "2")
                {
                    Console.Write("\nEnter username: ");
                    string username = Console.ReadLine().Trim();
                    if (registerService.Register(username))
                    {
                        // logged in as new user
                        var loggedCustomerId = registerService.NewCustomer.CustomerId;
                        UserMenuLoop(loggedCustomerId, bookingService, cancellationService, adminService);
                    }
                }
                else if (ch == "3")
                {
                    Console.Write("\nEnter username or email: ");
                    var user = Console.ReadLine().Trim();
                    Console.Write("Enter password: ");
                    var pass = Console.ReadLine().Trim();
                    if (loginService.UserLogin(user, pass))
                    {
                        var id = loginService.LoggedInCustomer.CustomerId;
                        Console.WriteLine($"\nWelcome {loginService.LoggedInCustomer.CustomerName}!");
                        UserMenuLoop(id, bookingService, cancellationService, adminService);
                    }
                }
                else if (ch == "4") 
                    break;
            }
        }

        static void UserMenuLoop(int customerId, BookingService bookingService, CancellationService cancellationService, AdminService adminService)
        {
            while (true)
            {
                Console.WriteLine("\n--- User Menu ---");
                Console.WriteLine("1. Book Tickets");
                Console.WriteLine("2. View Bookings");
                Console.WriteLine("3. Cancel Tickets");
                Console.WriteLine("4. View Cancellations");
                Console.WriteLine("5. Search Trains");
                Console.WriteLine("6. Logout");
                Console.Write("\nChoose: ");
                var u = Console.ReadLine();
                if (u == "1") 
                    bookingService.SearchAndBook(customerId);
                else if (u == "2") 
                    bookingService.ViewBookingsForCustomer(customerId);
                else if (u == "3") 
                    cancellationService.CancelReservation(customerId);
                else if (u == "4") 
                    cancellationService.ViewCancellationsForCustomer(customerId);
                else if (u == "5") 
                    bookingService.SearchAndBook(customerId); // after search, booking flow continues if user wants to
                else if (u == "6") 
                    break;
            }
        }
    }
}
