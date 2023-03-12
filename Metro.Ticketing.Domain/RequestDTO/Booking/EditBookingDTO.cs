using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro.Ticketing.Domain.RequestDTO.Booking
{
    public class EditBookingDTO
    {
        public Guid BookingId { get; set; }
        public Guid? TrainId { get; set; }
        public Guid? PassengerId { get; set; }
        public Guid UserId { get; set; }
        public double Fare { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public int SeatNum { get; set; }
        public bool isActive { get; set; }
    }
}
