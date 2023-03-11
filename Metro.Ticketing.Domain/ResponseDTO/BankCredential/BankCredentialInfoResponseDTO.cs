using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro.Ticketing.Domain.ResponseDTO.BankCredential
{
    public class BankCredentialInfoResponseDTO
    {
        public Guid BankCredId { get; set; }
        public Guid? UserId { get; set; }
        public string BankName { get; set; }
        public string CardNumber { get; set; }
        public bool isActive { get; set; }
    }
}
