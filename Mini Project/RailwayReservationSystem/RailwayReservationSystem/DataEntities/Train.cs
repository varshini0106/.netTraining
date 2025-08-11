using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservationSystem.DataEntities
{
    public class Train
    {
        public int TrainNo { get; set; }
        public string TrainName { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }

        // Seat availability for each class
        public int SleeperSeats { get; set; }
        public int AC2Seats { get; set; }
        public int AC3Seats { get; set; }

        // Cost per class
        public decimal SleeperFare { get; set; }
        public decimal AC2Fare { get; set; }
        public decimal AC3Fare { get; set; }

        public bool IsDeleted { get; set; }
    }
}
