using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro.Ticketing.Domain.ResponseDTO.Seat
{
    public class SeatInfoResponseDTO
    {
        public Guid SeatId { get; set; }
        public Guid TrainId { get; set; }
        public int Total { get; set; }
    }
}
