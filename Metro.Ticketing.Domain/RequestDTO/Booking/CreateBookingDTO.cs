using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro.Ticketing.Domain.RequestDTO.Booking
{
    public class CreateBookingDTO
    {
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
