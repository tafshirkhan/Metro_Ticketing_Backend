using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro.Ticketing.Domain.RequestDTO.Seat
{
    public class EditSeatDTO
    {
        public Guid SeatId { get; set; }
        public Guid TrainId { get; set; }

        public int Total { get; set; }
    }
}
