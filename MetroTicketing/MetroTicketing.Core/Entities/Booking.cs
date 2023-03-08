using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroTicketing.System.Domain.Entities
{
    public class Booking
    {

        [Key]
        public int BookingId { get; set; }

        [ForeignKey("TrainId")]
        public int? TrainId { get; set; }

        [ForeignKey("PassengerId")]
        public int? PassengerId { get; set; }
        public int UserId { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public double fare { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime Date { get; set; }


        public string Status { get; set; }

        public int SeatNum { get; set; }

        public bool isActive { get; set; }
        public ICollection<Transaction> transactions { get; set; }
    }
}
