using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseExampleAngularCore.Models
{
    public class TripModel
    {
        public string HotelName { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string[] Assets { get; set; }
        public string Price { get; set; }
        public string Date { get; set; }
        public int HowLong { get; set; }
    }
}
