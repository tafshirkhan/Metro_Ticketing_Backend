using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroTicketing.System.Entities
{
    public class Transaction
    {

        [Key]
        [Required]
        public Guid TransactionId { get; set; }
        [ForeignKey("BookingId")]
        public Guid? BookingId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public double Fare { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string TransactionStatus { get; set; }
        public ICollection<Ticket> tickets { get; set; }
    }
}
