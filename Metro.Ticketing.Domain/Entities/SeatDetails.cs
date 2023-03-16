using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro.Ticketing.Domain.Entities
{
    public class SeatDetails
    {
        public Guid SeatId { get; set; }

        public Guid TrainId { get; set; }
        public string TrainName { get; set; }

        public int Total { get; set; }
    }
}
