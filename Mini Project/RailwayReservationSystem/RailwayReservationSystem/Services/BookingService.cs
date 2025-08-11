using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using RailwayReservationSystem.DataEntities;

namespace RailwayReservationSystem.Services
{
    public class BookingService
    {
        public Reservation CurrentReservation { get; set; }
        public BookingService()
        {
            CurrentReservation = new Reservation();
        }

        public void SearchAndBook(int customerId)
        {
            Console.Write("Enter source: ");
            var src = Console.ReadLine().Trim();
            Console.Write("Enter destination: ");
            var dst = Console.ReadLine().Trim();

            using (var con = DbConnection.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("select TrainNo,TrainName,Source,Destination,SleeperSeats,AC2Seats,AC3Seats,SleeperFare,AC2Fare,AC3Fare " +
                    "from Trains where Source=@s and Destination=@d and IsDeleted=0", con);
                cmd.Parameters.AddWithValue("@s", src);
                cmd.Parameters.AddWithValue("@d", dst);
                using (var rdr = cmd.ExecuteReader())
                {
                    if (!rdr.HasRows) 
                    { 
                        Console.WriteLine("\nNo trains available"); 
                        return; 
                    }
                    Console.WriteLine("\nAvailable Trains:");
                    Console.WriteLine("---------------------");
                    while (rdr.Read())
                    {
                        Console.WriteLine($"\nTrainNo:{rdr[0]} \nName:{rdr[1]} \nSleeper:{rdr[4]} seats (Fare {rdr[7]}) \n2AC:{rdr[5]} (Fare {rdr[8]}) \n3AC:{rdr[6]} (Fare {rdr[9]})");
                    }
                }

                // Ask for user consent to proceed with the booking
                Console.Write("\nDo you want to proceed with booking? (Y/N): ");
                var consent = Console.ReadLine().Trim().ToUpper();
                if (consent != "Y")
                {
                    Console.WriteLine("\nReturning to main menu...");
                    return;
                }

                Console.Write("\nEnter train number to book: "); 
                CurrentReservation.TrainNo = int.Parse(Console.ReadLine());
                DateTime travelDate;
                do
                {
                    Console.Write("Enter travel date (YYYY-MM-DD): ");
                    string inputDate = Console.ReadLine().Trim();

                    if (!DateTime.TryParse(inputDate, out travelDate))
                    {
                        Console.WriteLine("Invalid format. Please enter date in YYYY-MM-DD format.");
                        continue;
                    }

                    if (travelDate <= DateTime.Today)
                    {
                        Console.WriteLine("Invalid date. Travel date must be after today's date.");
                    }
                    else
                    {
                        break;
                    }

                } while (true);
                CurrentReservation.TravelDate = travelDate.ToString("yyyy-MM-dd");
                Console.Write("Enter class (Sleeper/2AC/3AC): "); 
                CurrentReservation.ClassType = Console.ReadLine().Trim();
                Console.Write("Enter berth (Lower/Middle/Upper): "); 
                CurrentReservation.Berth = Console.ReadLine().Trim();
                Console.Write("Enter number of seats: "); 
                CurrentReservation.NumberOfSeats = int.Parse(Console.ReadLine());

                // fetch fare for calculation
                var fareCmd = new SqlCommand("select SleeperFare,AC2Fare,AC3Fare from Trains where TrainNo=@tno", con);
                fareCmd.Parameters.AddWithValue("@tno", CurrentReservation.TrainNo);
                using (var fr = fareCmd.ExecuteReader())
                {
                    if (fr.Read())
                    {
                        decimal fare = 0;
                        if (CurrentReservation.ClassType.Equals("Sleeper", StringComparison.OrdinalIgnoreCase)) fare = Convert.ToDecimal(fr[0]);
                        else if (CurrentReservation.ClassType.Equals("2AC", StringComparison.OrdinalIgnoreCase)) fare = Convert.ToDecimal(fr[1]);
                        else if (CurrentReservation.ClassType.Equals("3AC", StringComparison.OrdinalIgnoreCase)) fare = Convert.ToDecimal(fr[2]);

                        CurrentReservation.TotalFare = fare * CurrentReservation.NumberOfSeats;
                    }
                }                

                bool confirmed = false;

                while (!confirmed)
                {
                    Console.WriteLine("\nPlease check the details below");
                    Console.WriteLine($"CustomerId:{customerId} \nTrain:{CurrentReservation.TrainNo} \nDate:{CurrentReservation.TravelDate} \nClass:{CurrentReservation.ClassType}, Berth:{CurrentReservation.Berth}, Seats:{CurrentReservation.NumberOfSeats} \nTotal Fare:{CurrentReservation.TotalFare}");

                    Console.Write("\nConfirm booking? (Y to confirm / N to cancel / E to edit): ");
                    var choice = Console.ReadLine().Trim().ToUpper();

                    if (choice == "Y")
                    {
                        confirmed = true;
                    }
                    else if (choice == "N")
                    {
                        Console.WriteLine("\nBooking cancelled. Returning to main menu...");
                        return;
                    }
                    else if (choice == "E")
                    {
                        Console.WriteLine("\nWhich field would you like to edit?");
                        Console.WriteLine("1. Travel Date");
                        Console.WriteLine("2. Class Type");
                        Console.WriteLine("3. Berth");
                        Console.WriteLine("4. Number of Seats");
                        Console.Write("\nEnter your choice (1-4): ");
                        var fieldChoice = Console.ReadLine().Trim();

                        switch (fieldChoice)
                        {
                            case "1":
                                Console.Write("\nEnter new travel date (yyyy-MM-dd): ");
                                CurrentReservation.TravelDate = Console.ReadLine().Trim();
                                break;

                            case "2":
                                Console.Write("\nEnter new class (Sleeper/2AC/3AC): ");
                                CurrentReservation.ClassType = Console.ReadLine().Trim();
                                break;

                            case "3":
                                Console.Write("\nEnter new berth (Lower/Middle/Upper): ");
                                CurrentReservation.Berth = Console.ReadLine().Trim();
                                break;

                            case "4":
                                Console.Write("\nEnter new number of seats: ");
                                CurrentReservation.NumberOfSeats = int.Parse(Console.ReadLine());
                                break;

                            default:
                                Console.WriteLine("\nInvalid choice. Returning to confirmation...");
                                break;
                        }

                        // Recalculate fare after edits
                        var newFareCmd = new SqlCommand("select SleeperFare, AC2Fare, AC3Fare from Trains where TrainNo = @tno", con);
                        newFareCmd.Parameters.AddWithValue("@tno", CurrentReservation.TrainNo);
                        using (var fr = newFareCmd.ExecuteReader())
                        {
                            if (fr.Read())
                            {
                                decimal fare = 0;
                                if (CurrentReservation.ClassType.Equals("Sleeper", StringComparison.OrdinalIgnoreCase)) fare = Convert.ToDecimal(fr["SleeperFare"]);
                                else if (CurrentReservation.ClassType.Equals("2AC", StringComparison.OrdinalIgnoreCase)) fare = Convert.ToDecimal(fr["AC2Fare"]);
                                else if (CurrentReservation.ClassType.Equals("3AC", StringComparison.OrdinalIgnoreCase)) fare = Convert.ToDecimal(fr["AC3Fare"]);

                                CurrentReservation.TotalFare = fare * CurrentReservation.NumberOfSeats;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input. Please enter Y to confirm / N to cancel / E to edit.");
                    }
                }                

                // Call stored procedure to insert reservation and update seats atomically
                var sp = new SqlCommand("sp_AddReservation", con);
                sp.CommandType = System.Data.CommandType.StoredProcedure;
                sp.Parameters.AddWithValue("@CustomerId", customerId);
                sp.Parameters.AddWithValue("@TrainNo", CurrentReservation.TrainNo);
                sp.Parameters.AddWithValue("@TravelDate", CurrentReservation.TravelDate);
                sp.Parameters.AddWithValue("@ClassType", CurrentReservation.ClassType);
                sp.Parameters.AddWithValue("@Berth", CurrentReservation.Berth);
                sp.Parameters.AddWithValue("@NumberOfSeats", CurrentReservation.NumberOfSeats);
                sp.Parameters.AddWithValue("@TotalFare", CurrentReservation.TotalFare);

                var res = sp.ExecuteScalar(); // expects new ReservationId returned
                var reservationId = Convert.ToInt32(res);

                Console.WriteLine("\nBooking confirmed!\n");
                PrintTicket(reservationId, customerId);
            }
        }

        public void PrintTicket(int reservationId, int customerId)
        {
            using (var con = DbConnection.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("select r.ReservationId,c.CustomerName,r.TrainNo,r.TravelDate,r.ClassType,r.Berth,r.NumberOfSeats,r.TotalFare " +
                    "from Reservations r join Customers c on r.CustomerId=c.CustomerId where r.ReservationId=@rid", con);
                cmd.Parameters.AddWithValue("@rid", reservationId);
                using (var rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        Console.WriteLine("--------- RAILWAY TICKET ---------");
                        Console.WriteLine($"ReservationId: {rdr[0]}");
                        Console.WriteLine($"Passenger: {rdr[1]}");
                        Console.WriteLine($"TrainNo: {rdr[2]}");
                        Console.WriteLine($"TravelDate: {rdr[3]}");
                        Console.WriteLine($"Class: {rdr[4]}, Berth: {rdr[5]}");
                        Console.WriteLine($"Seats: {rdr[6]}, Total Fare: {rdr[7]}");
                        Console.WriteLine("----------------------------------");
                    }
                }
            }
        }

        public void ViewBookingsForCustomer(int customerId)
        {
            using (var con = DbConnection.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("select ReservationId,TrainNo,TravelDate,ClassType,Berth,NumberOfSeats,TotalFare,BookingDate,IsCancelled from Reservations where CustomerId=@cid", con);
                cmd.Parameters.AddWithValue("@cid", customerId);
                using (var rdr = cmd.ExecuteReader())
                {
                    if (!rdr.HasRows) 
                    { 
                        Console.WriteLine("\nNo bookings done yet!"); 
                        return; 
                    }
                    Console.WriteLine("\nYOUR BOOKINGS!!");
                    Console.WriteLine("-----------------");
                    while (rdr.Read())
                    {
                        Console.WriteLine($"\nReservation ID:{rdr[0]} \nTrain No:{rdr[1]} \nDate:{rdr[2]} \nClass:{rdr[3]} \nSeats:{rdr[5]} \nFare:{rdr[6]} \nCancelled:{rdr[8]}");
                        Console.WriteLine("\n------------------------");
                    }
                }
            }
        }
    }
}
