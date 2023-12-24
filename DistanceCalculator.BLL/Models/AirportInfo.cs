using System;
using System.Collections.Generic;
using System.Text;

namespace DistanceCalculator.BLL.Models
{
    public class AirportInfo
    {
        public string IATA { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
    }
}
