using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro.Ticketing.Domain.RequestDTO.BankCredential
{
    public class EditBankCredentialDTO
    {
        public Guid BankCredId { get; set; }     
        public Guid? UserId { get; set; }     
        public string BankName { get; set; }
        public string CardNumber { get; set; }
        public bool isActive { get; set; }
    }
}
