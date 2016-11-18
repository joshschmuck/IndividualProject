using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace WeatherApp.Models
{
    public class Weather
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Item { get; set; }

    }
}
