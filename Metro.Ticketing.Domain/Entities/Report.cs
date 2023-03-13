using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroTicketing.System.Entities
{
    public class Report
    {
        public Guid PassengerId { get; set; }
        public string PassengerName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public Guid BookingId { get; set; }
        public double Fare { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public int SeatNum { get; set; }
    }
}
