using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroTicketing.System.Entities
{
    public class Passenger
    {
        [Key]
        public Guid PassengerId { get; set; }

        public Guid UserId { get; set; }

        public string PassengerName { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

    }
}
