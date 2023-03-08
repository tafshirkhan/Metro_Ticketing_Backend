using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroTicketing.System.Domain.Entities
{
    public class Seat
    {
        [Key]
        [Required]
        public int SeatId { get; set; }

        public int TrainId { get; set; }

        public int Total { get; set; }
    }
}
