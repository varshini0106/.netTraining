using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservationSystem.DataEntities
{
    public class Cancellation
    {
        public int CancellationId { get; set; }
        public int ReservationId { get; set; }
        public int CustomerId { get; set; }
        public DateTime CancellationDate { get; set; }
        public int SeatsCancelled { get; set; }
        public decimal RefundAmount { get; set; }
    }
}
