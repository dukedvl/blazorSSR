using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForager
{
    public class DailyWeatherModel
    {
        public DateTime created_at { get; set; }
        public double high { get; set; }

        public double low { get; set; }

        public string moon_phase { get; set; }

        public string weather_code { get; set; }

        public DateTime weather_time { get; set; }

        public DateTime sunrise_time { get; set; }

        public DateTime sunset_time { get; set; }

        public string ToDisplaySummary()
        {
            StringBuilder display = new StringBuilder();
            display.Append($"{weather_time.ToLocalTime().ToShortTimeString()}\t\t");
            display.Append($"{high} F\t\t");
            display.Append(weather_code.ToString().Replace('_', ' '));

            return display.ToString();
        }

        public string GetImagePath()
        {
            return FormattingUtilities.GetImagePath(weather_code.ToString());
        }

        public string GetMoonPhasePath()
        {
            return moon_phase switch
            {
               "New"=> "img/new-moon-phase-circle.png",
               "Waxing_Crescent"=> "img/moon-phase-interface-symbol.png",
               "First_Quarter"=> "img/half-moon-phase-symbol.png",
               "Waxing_Gibbous"=> "img/moon-phase-symbol-9.png",
               "Full"=> "img/moon-phase.png",
               "Waning_Gibbous"=> "img/moon-phase-symbol-14.png",
               "Third_Quarter"=> "img/moon-phase-symbol-3.png",
               "Waning_Crescent"=> "img/moon-phase-symbol-12.png",
                _ => "img/new-moon-phase-circle.png",
            };
        }

        public string GetMoonPhaseDisplay()
        {
            return moon_phase.ToString().ReformatClimaCellString();
        }

        public string GetWeatherCodeDisplay()
        {
            return weather_code.ToString().ReformatClimaCellString();
        }
    }

}
