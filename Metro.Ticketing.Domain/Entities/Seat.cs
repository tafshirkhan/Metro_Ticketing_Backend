using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroTicketing.System.Entities
{
    public class Seat
    {
        [Key]
        [Required]
        public Guid SeatId { get; set; }

        public Guid TrainId { get; set; }

        public int Total { get; set; }
    }
}
