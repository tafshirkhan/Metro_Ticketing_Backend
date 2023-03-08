using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroTicketing.System.Domain.Entities
{
    public class Passenger
    {
        [Key]
        public int PassengerId { get; set; }

        public int UserId { get; set; }

        public string PassengerName { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

    }
}
