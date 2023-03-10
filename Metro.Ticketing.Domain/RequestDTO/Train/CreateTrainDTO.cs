﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro.Ticketing.Domain.RequestDTO.Train
{
    public class CreateTrainDTO
    {
        public string Name { get; set; }
        public string ArrivalTime { get; set; }
        public string DepartureTime { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public string ArrivalStation { get; set; }
        public string DepartureStation { get; set; }
        public double Distance { get; set; }
        public bool isActive { get; set; }
    }
}
