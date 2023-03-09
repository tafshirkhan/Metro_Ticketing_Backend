using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroTicketing.System.Entities
{
    public class Ticket
    {
        [Key]
        public Guid TicketId { get; set; }

        public Guid PassengerId { get; set; }

        public Guid BookingId { get; set; }

        public Guid TrainId { get; set; }
    }
}
