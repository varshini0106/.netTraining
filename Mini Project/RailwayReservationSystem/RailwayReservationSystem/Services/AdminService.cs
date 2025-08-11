using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using RailwayReservationSystem.DataEntities;

namespace RailwayReservationSystem.Services
{
    public class AdminService
    {
        public void AddTrain()
        {
            var t = new Train();
            Console.Write("\nEnter Train No (integer): "); 
            t.TrainNo = int.Parse(Console.ReadLine());
            Console.Write("Enter Train Name: "); 
            t.TrainName = Console.ReadLine().Trim();
            Console.Write("Enter Source: "); 
            t.Source = Console.ReadLine().Trim();
            Console.Write("Enter Destination: "); 
            t.Destination = Console.ReadLine().Trim();

            Console.Write("Enter Sleeper seats count: "); 
            t.SleeperSeats = int.Parse(Console.ReadLine());
            Console.Write("Enter 2AC seats count: "); 
            t.AC2Seats = int.Parse(Console.ReadLine());
            Console.Write("Enter 3AC seats count: "); 
            t.AC3Seats = int.Parse(Console.ReadLine());

            Console.Write("Enter Sleeper fare: "); 
            t.SleeperFare = decimal.Parse(Console.ReadLine());
            Console.Write("Enter 2AC fare: "); 
            t.AC2Fare = decimal.Parse(Console.ReadLine());
            Console.Write("Enter 3AC fare: "); 
            t.AC3Fare = decimal.Parse(Console.ReadLine());

            using (var con = DbConnection.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand(@"insert into Trains(TrainNo,TrainName,Source,Destination,SleeperSeats,AC2Seats,AC3Seats,SleeperFare,AC2Fare,AC3Fare,IsDeleted)
                                           values(@TrainNo,@TrainName,@Source,@Destination,@S1,@A2,@A3,@F1,@F2,@F3,0)", con);
                cmd.Parameters.AddWithValue("@TrainNo", t.TrainNo);
                cmd.Parameters.AddWithValue("@TrainName", t.TrainName);
                cmd.Parameters.AddWithValue("@Source", t.Source);
                cmd.Parameters.AddWithValue("@Destination", t.Destination);
                cmd.Parameters.AddWithValue("@S1", t.SleeperSeats);
                cmd.Parameters.AddWithValue("@A2", t.AC2Seats);
                cmd.Parameters.AddWithValue("@A3", t.AC3Seats);
                cmd.Parameters.AddWithValue("@F1", t.SleeperFare);
                cmd.Parameters.AddWithValue("@F2", t.AC2Fare);
                cmd.Parameters.AddWithValue("@F3", t.AC3Fare);
                cmd.ExecuteNonQuery();
            }
            Console.WriteLine("\nTrain added successfully.");
        }

        public void UpdateTrain()
        {
            Console.Write("\nEnter Train No to update: ");
            var tno = int.Parse(Console.ReadLine());
            using (var con = DbConnection.GetConnection())
            {
                con.Open();
                var sel = new SqlCommand("select * from Trains where TrainNo=@tno and IsDeleted=0", con);
                sel.Parameters.AddWithValue("@tno", tno);
                using (var rdr = sel.ExecuteReader())
                {
                    if (!rdr.Read()) 
                    { 
                        Console.WriteLine("\nTrain not found."); 
                        return; 
                    }
                }

                Console.WriteLine("\nEnter fields to update (leave blank to skip):");
                Console.Write("Train Name: "); var name = Console.ReadLine();
                Console.Write("Source: "); var src = Console.ReadLine();
                Console.Write("Destination: "); var dst = Console.ReadLine();
                Console.Write("Sleeper seats: "); var s1 = Console.ReadLine();
                Console.Write("2AC seats: "); var a2 = Console.ReadLine();
                Console.Write("3AC seats: "); var a3 = Console.ReadLine();
                Console.Write("Sleeper fare: "); var f1 = Console.ReadLine();
                Console.Write("2AC fare: "); var f2 = Console.ReadLine();
                Console.Write("3AC fare: "); var f3 = Console.ReadLine();

                var upd = new SqlCommand(@"update Trains set
                                            TrainName = case when @name<>'' then @name else TrainName end,
                                            Source = case when @src<>'' then @src else Source end,
                                            Destination = case when @dst<>'' then @dst else Destination end,
                                            SleeperSeats = case when @s1<>'' then @s1 else SleeperSeats end,
                                            AC2Seats = case when @a2<>'' then @a2 else AC2Seats end,
                                            AC3Seats = case when @a3<>'' then @a3 else AC3Seats end,
                                            SleeperFare = case when @f1<>'' then @f1 else SleeperFare end,
                                            AC2Fare = case when @f2<>'' then @f2 else AC2Fare end,
                                            AC3Fare = case when @f3<>'' then @f3 else AC3Fare end
                                            where TrainNo=@tno", con);

                upd.Parameters.AddWithValue("@name", name ?? string.Empty);
                upd.Parameters.AddWithValue("@src", src ?? string.Empty);
                upd.Parameters.AddWithValue("@dst", dst ?? string.Empty);
                upd.Parameters.AddWithValue("@s1", string.IsNullOrEmpty(s1) ? string.Empty : s1);
                upd.Parameters.AddWithValue("@a2", string.IsNullOrEmpty(a2) ? string.Empty : a2);
                upd.Parameters.AddWithValue("@a3", string.IsNullOrEmpty(a3) ? string.Empty : a3);
                upd.Parameters.AddWithValue("@f1", string.IsNullOrEmpty(f1) ? string.Empty : f1);
                upd.Parameters.AddWithValue("@f2", string.IsNullOrEmpty(f2) ? string.Empty : f2);
                upd.Parameters.AddWithValue("@f3", string.IsNullOrEmpty(f3) ? string.Empty : f3);
                upd.Parameters.AddWithValue("@tno", tno);
                upd.ExecuteNonQuery();
            }
            Console.WriteLine("\nTrain updated (partial updates applied where provided).");
        }

        public void DeleteTrain(bool softDelete = true)
        {
            Console.Write("\nEnter Train No to delete: ");
            var tno = int.Parse(Console.ReadLine());
            using (var con = DbConnection.GetConnection())
            {
                con.Open();
                if (softDelete)
                {
                    var cmd = new SqlCommand("update Trains set IsDeleted=1 where TrainNo=@tno", con);
                    cmd.Parameters.AddWithValue("@tno", tno);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("\nTrain soft-deleted.");
                }                
            }
        }

        public void ViewAllReservations()
        {
            using (var con = DbConnection.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("select r.ReservationId,c.CustomerName,r.TrainNo,r.TravelDate,r.ClassType,r.Berth,r.NumberOfSeats,r.TotalFare,r.BookingDate,r.IsCancelled " +
                    "from Reservations r join Customers c on r.CustomerId=c.CustomerId order by r.BookingDate desc", con);
                using (var rdr = cmd.ExecuteReader())
                {
                    if (!rdr.HasRows) 
                    { 
                        Console.WriteLine("\nNo bookings done yet!"); 
                        return; 
                    }
                    Console.WriteLine("\nALL RESERVATIONS!!");
                    Console.WriteLine("-------------------------");
                    while (rdr.Read())
                    {                        
                        Console.WriteLine($"\nReservationId: {rdr[0]} \nCustomer: {rdr[1]} \nTrainNo: {rdr[2]} \nTravelDate: {rdr[3]} \nClass: {rdr[4]}, Berth: {rdr[5]}, Seats: {rdr[6]} \nFare: {rdr[7]} \nBookedOn: {rdr[8]} \nCancelled: {rdr[9]}");
                        Console.WriteLine("\n-------------------------");
                    }
                }
            }
        }

        public void ViewRegisteredCustomers()
        {
            using (var con = DbConnection.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("select CustomerId,CustomerName,Phone,Email,Username from Customers where IsDeleted=0", con);
                using (var rdr = cmd.ExecuteReader())
                {
                    Console.WriteLine("\nREGISTERED CUSTOMERS!!");
                    Console.WriteLine("-------------------------");
                    while (rdr.Read())
                    {
                        Console.WriteLine($"\nId: {rdr[0]} \nName: {rdr[1]} \nPhone: {rdr[2]} \nEmail: {rdr[3]} \nUsername: {rdr[4]}");
                        Console.WriteLine("\n-----------------------------");
                    }
                }
            }
        }

        public void ViewAllCancellations()
        {
            using (var con = DbConnection.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("select * from Cancellations order by CancellationDate desc", con);
                using (var rdr = cmd.ExecuteReader())
                {
                    if (!rdr.HasRows) 
                    { 
                        Console.WriteLine("\nNo cancellations done yet!"); 
                        return; 
                    }
                    Console.WriteLine("\nALL CANCELLATIONS!!");
                    Console.WriteLine("-------------------------");
                    while (rdr.Read())
                    {
                        Console.WriteLine($"\nCancellationId:{rdr[0]} \nReservationId:{rdr[1]} \nCustomerId:{rdr[2]} \nDate:{rdr[3]} \nSeats:{rdr[4]} \nRefund:{rdr[5]}");
                        Console.WriteLine("\n------------------------");
                    }
                }
            }
        }
    }
}
