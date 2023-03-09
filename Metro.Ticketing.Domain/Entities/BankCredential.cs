using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroTicketing.System.Entities
{
    public class BankCredential
    {
        [Key]
        [Required]
        public Guid BankCredId { get; set; }
        [Required]
        [ForeignKey("UserId")]
        public Guid? UserId { get; set; }
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
