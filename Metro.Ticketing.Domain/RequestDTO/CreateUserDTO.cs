using MetroTicketing.System.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankCredential = MetroTicketing.System.Entities.BankCredential;

namespace Metro.Ticketing.Domain.RequestDTO
{
    public class CreateUserDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        //public ICollection<MetroTicketing.System.Entities.BankCredential> bankCreds { get; set; }
        //public ICollection<Ticket> tickets { get; set; }
    }
}
