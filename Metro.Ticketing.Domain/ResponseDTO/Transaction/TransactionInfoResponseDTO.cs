using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro.Ticketing.Domain.ResponseDTO.Transaction
{
    public class TransactionInfoResponseDTO
    {
        public Guid TransactionId { get; set; }
        public Guid? BookingId { get; set; }
        public double Fare { get; set; }
        public string TransactionStatus { get; set; }
    }
}
