using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroTicketing.System.Entities
{
    public class SearchTrain
    {
        public Guid TrainId { get; set; }

        [Column(TypeName = "varchar(25)")]
        [Required]
        [MinLength(5)]
        public string TrainName { get; set; }

        public string ArrivalTime { get; set; }
        public string DepartureTime { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime ArrivalDate { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime DepartureDate { get; set; }
        public string ArrivalStation { get; set; }
        public string DepartureStation { get; set; }
        public double Distance { get; set; }
        public int Total { get; set; }
    }
}
