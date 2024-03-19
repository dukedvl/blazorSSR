using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForager
{
    public class InstantWeatherModel
    {
        public double temp { get; set; }

        public double feels_like { get; set; }

        public DateTime observation_time { get; set; } = DateTime.Now; 

        public string ToDisplaySummary()
        {
            return $"{temp:00.00} F\t(Feels Like: {feels_like} F)";
        }
    }
}
