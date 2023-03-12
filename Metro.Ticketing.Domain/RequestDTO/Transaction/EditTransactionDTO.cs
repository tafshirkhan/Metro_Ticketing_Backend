using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro.Ticketing.Domain.RequestDTO.Transaction
{
    public class EditTransactionDTO
    {
        public Guid TransactionId { get; set; }
        public Guid? BookingId { get; set; }
        public double Fare { get; set; }
        public string TransactionStatus { get; set; }
    }
}
