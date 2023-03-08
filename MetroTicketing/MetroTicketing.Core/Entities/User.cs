using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroTicketing.System.Domain.Entities
{
    public class User
    {
        [Key]
        [Required]
        public int UserId { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Email { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required]
        public string Address { get; set; }
        public string Mobile { get; set; }

        [Column(TypeName = "varchar(25)")]
        [Required]
        public string Password { get; set; }

        [Column(TypeName = "varchar(15)")]
        public string Role { get; set; }

        public bool IsActive { get; set; }
        public ICollection<BankCredential> bankCreds { get; set; }
        public ICollection<Ticket> tickets { get; set; }
    }
}
