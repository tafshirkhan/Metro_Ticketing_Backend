using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroTicketing.System.Entities
{
    public class Booking
    {

        [Key]
        public Guid BookingId { get; set; }

        [ForeignKey("TrainId")]
        public Guid? TrainId { get; set; }

        [ForeignKey("PassengerId")]
        public Guid? PassengerId { get; set; }
        public Guid UserId { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public double Fare { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime Date { get; set; }


        public string Status { get; set; }

        public int SeatNum { get; set; }

        public bool isActive { get; set; }
        public ICollection<Transaction> transactions { get; set; }
    }
}
