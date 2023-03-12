using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro.Ticketing.Domain.RequestDTO.Ticket
{
    public class EditTicketDTO
    {
        public Guid TicketId { get; set; }

        public Guid PassengerId { get; set; }

        public Guid BookingId { get; set; }

        public Guid TrainId { get; set; }
    }
}
