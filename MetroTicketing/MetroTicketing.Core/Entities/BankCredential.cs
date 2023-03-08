using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroTicketing.System.Domain.Entities
{
    public class BankCredential
    {
        [Key]
        [Required]
        public int BankCredId { get; set; }
        [Required]
        [ForeignKey("UserId")]
        public int? UserId { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string BankName { get; set; }
        [MinLength(4)]
        [MaxLength(11)]
        [Required]
        public string CardNumber { get; set; }
        public bool isActive { get; set; }
    }
}
