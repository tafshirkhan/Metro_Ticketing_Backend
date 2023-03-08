using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroTicketing.System.Domain.Entities
{
    public class TicketDetails
    {
        public int BookingId { get; set; }

        public int? TrainId { get; set; }

        public int? PassengerId { get; set; }

        public double Fare { get; set; }
        public string Status { get; set; }

        public int SeatNum { get; set; }
        public string PassengerName { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public string Name { get; set; }

        public string ArrivalTime { get; set; }

        public string DepartureTime { get; set; }

        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public string ArrivalStation { get; set; }
        public string DepartureStation { get; set; }
    }
}
