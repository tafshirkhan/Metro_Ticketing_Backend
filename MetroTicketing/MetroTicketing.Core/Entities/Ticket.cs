using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroTicketing.System.Domain.Entities
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }

        public int PassengerId { get; set; }

        public int BookingId { get; set; }

        public int TrainId { get; set; }
    }
}
