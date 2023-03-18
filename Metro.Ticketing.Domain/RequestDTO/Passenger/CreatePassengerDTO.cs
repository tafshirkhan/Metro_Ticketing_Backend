using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro.Ticketing.Domain.RequestDTO.Passenger
{
    public class CreatePassengerDTO
    {
       // public Guid PassengerId { get; set; }

        public Guid UserId { get; set; }

        public string PassengerName { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }
    }
}
