using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using RailwayReservationSystem.DataEntities;

namespace RailwayReservationSystem.Services
{
    public class CancellationService
    {
        public void CancelReservation(int customerId)
        {
            Console.Write("Enter Reservation Id to cancel: ");
            int rid = int.Parse(Console.ReadLine());

            Console.Write("How many seats to cancel: ");
            int seatsToCancel = int.Parse(Console.ReadLine());

            using (var con = DbConnection.GetConnection())
            {
                con.Open();

                var cmd = new SqlCommand(
                    @"select ReservationId, CustomerId, TrainNo, NumberOfSeats, TotalFare, BookingDate, ClassType
                      from Reservations
                      where ReservationId = @rid and CustomerId = @cid and IsCancelled = 0", con);
                cmd.Parameters.AddWithValue("@rid", rid);
                cmd.Parameters.AddWithValue("@cid", customerId);

                using (var rdr = cmd.ExecuteReader())
                {
                    if (!rdr.Read())
                    {
                        Console.WriteLine("\nReservation not found or already cancelled.");
                        return;
                    }

                    int bookedSeats = Convert.ToInt32(rdr["NumberOfSeats"]);
                    decimal totalFare = Convert.ToDecimal(rdr["TotalFare"]);
                    DateTime bookingDate = Convert.ToDateTime(rdr["BookingDate"]);
                    string classType = rdr["ClassType"].ToString();

                    if (seatsToCancel > bookedSeats)
                    {
                        Console.WriteLine("\nYou are trying to cancel more seats than booked.");
                        return;
                    }

                    // Calculate days since booking
                    double days = (DateTime.Now - bookingDate).TotalDays;
                    decimal refundPercent;

                    if (days <= 30)
                        refundPercent = 0.60m; // highest refund if cancelled early
                    else if (days <= 60)
                        refundPercent = 0.35m;
                    else if (days <= 90)
                        refundPercent = 0.20m;
                    else
                        refundPercent = 0m;

                    decimal perSeatFare = totalFare / bookedSeats;
                    decimal refundAmount = perSeatFare * seatsToCancel * refundPercent;

                    Console.WriteLine("\nCancellation Summary:");
                    Console.WriteLine($"Reservation ID: {rid}");
                    Console.WriteLine($"Seats to Cancel: {seatsToCancel}");
                    Console.WriteLine($"Refund Amount: {refundAmount}");
                    Console.Write("\nDo you want to proceed with cancellation? (Y/N): ");
                    string confirm = Console.ReadLine().Trim().ToUpper();

                    if (confirm != "Y")
                    {
                        Console.WriteLine("\nCancellation aborted. Returning to menu...");
                        return;
                    }

                    rdr.Close();

                    var tran = con.BeginTransaction();
                    try
                    {
                        var cancellation = new Cancellation
                        {
                            ReservationId = rid,
                            CustomerId = customerId,
                            CancellationDate = DateTime.Now,
                            SeatsCancelled = seatsToCancel,
                            RefundAmount = refundAmount
                        };

                        var ins = new SqlCommand(
                            @"insert into Cancellations (ReservationId, CustomerId, CancellationDate, SeatsCancelled, RefundAmount)
                              values (@rid, @cid, @cdate, @sc, @refamt);", con, tran);
                        ins.Parameters.AddWithValue("@rid", cancellation.ReservationId);
                        ins.Parameters.AddWithValue("@cid", cancellation.CustomerId);
                        ins.Parameters.AddWithValue("@cdate", cancellation.CancellationDate);
                        ins.Parameters.AddWithValue("@sc", cancellation.SeatsCancelled);
                        ins.Parameters.AddWithValue("@refamt", cancellation.RefundAmount);
                        ins.ExecuteNonQuery();

                        if (seatsToCancel == bookedSeats)
                        {
                            var updRes = new SqlCommand(
                                "update Reservations set IsCancelled = 1 where ReservationId = @rid", con, tran);
                            updRes.Parameters.AddWithValue("@rid", rid);
                            updRes.ExecuteNonQuery();
                        }
                        else
                        {
                            var updRes = new SqlCommand(
                                @"update Reservations
                                  set NumberOfSeats = NumberOfSeats - @sc,
                                      TotalFare = TotalFare - @fare
                                  where ReservationId = @rid", con, tran);
                            updRes.Parameters.AddWithValue("@sc", seatsToCancel);
                            updRes.Parameters.AddWithValue("@fare", perSeatFare * seatsToCancel);
                            updRes.Parameters.AddWithValue("@rid", rid);
                            updRes.ExecuteNonQuery();

                            string seatCol = classType.Equals("Sleeper", StringComparison.OrdinalIgnoreCase) ? "SleeperSeats"
                                : classType.Equals("2AC", StringComparison.OrdinalIgnoreCase) ? "AC2Seats"
                                : "AC3Seats";

                            var updTrain = new SqlCommand(
                                $@"update Trains
                                   set {seatCol} = {seatCol} + @sc
                                   where TrainNo = (select TrainNo from Reservations where ReservationId = @rid)", con, tran);
                            updTrain.Parameters.AddWithValue("@sc", seatsToCancel);
                            updTrain.Parameters.AddWithValue("@rid", rid);
                            updTrain.ExecuteNonQuery();
                        }

                        tran.Commit();
                        Console.WriteLine($"\nCancellation successful. Refund amount: {refundAmount}");
                    }
                    catch
                    {
                        tran.Rollback();
                        Console.WriteLine("\nCancellation failed. Try again.");
                    }
                }
            }
        }

        public void ViewCancellationsForCustomer(int customerId)
        {
            using (var con = DbConnection.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand(
                    @"select CancellationId, ReservationId, CancellationDate, SeatsCancelled, RefundAmount
                      from Cancellations
                      where CustomerId = @cid", con);
                cmd.Parameters.AddWithValue("@cid", customerId);

                using (var rdr = cmd.ExecuteReader())
                {
                    if (!rdr.HasRows)
                    {
                        Console.WriteLine("\nNo cancellations done yet!");
                        return;
                    }

                    Console.WriteLine("\nYOUR CANCELLATIONS!! ");
                    Console.WriteLine("-------------------------");
                    while (rdr.Read())
                    {
                        var cancellation = new Cancellation
                        {
                            CancellationId = Convert.ToInt32(rdr["CancellationId"]),
                            ReservationId = Convert.ToInt32(rdr["ReservationId"]),
                            CustomerId = customerId,
                            CancellationDate = Convert.ToDateTime(rdr["CancellationDate"]),
                            SeatsCancelled = Convert.ToInt32(rdr["SeatsCancelled"]),
                            RefundAmount = Convert.ToDecimal(rdr["RefundAmount"])
                        };

                        Console.WriteLine(
                            $"\nCustomer ID: {cancellation.CustomerId} \nCancellation ID: {cancellation.CancellationId} " +
                            $"\nReservation ID: {cancellation.ReservationId} \nCancellation Date: {cancellation.CancellationDate} " +
                            $"\nSeats: {cancellation.SeatsCancelled} \nRefund: {cancellation.RefundAmount}");
                    }
                }
            }
        }
    }
}
