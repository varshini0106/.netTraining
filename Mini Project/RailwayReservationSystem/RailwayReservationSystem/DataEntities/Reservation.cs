using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservationSystem.DataEntities
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int CustomerId { get; set; }
        public int TrainNo { get; set; }
        public string TravelDate { get; set; } // store as yyyy-MM-dd
        public string ClassType { get; set; } // Sleeper / 2AC / 3AC
        public string Berth { get; set; } // Lower / Middle / Upper
        public int NumberOfSeats { get; set; }
        public decimal TotalFare { get; set; }
        public DateTime BookingDate { get; set; }
        public bool IsCancelled { get; set; }
    }
}
