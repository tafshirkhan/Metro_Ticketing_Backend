using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroTicketing.System.Domain.Entities
{
    public class Login
    {

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Email { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Password { get; set; }
    }
}
