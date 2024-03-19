using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WeatherForager
{
    public class HourlyWeatherModel
    {
        public DateTime created_at { get; set; }
        public double temp { get; set; }

        public double feels_like { get; set; }

        public string weather_code { get; set; }

        public DateTime weather_time{ get; set; }

        public string precipitation_type { get; set; }

        public double precipitationProbability { get; set; }


        public double humidity { get; set; }

        public double dew_point { get; set; }

        public string ToDisplaySummary()
        {
            StringBuilder display = new StringBuilder();
            display.Append($"{weather_time.ToLocalTime().ToShortTimeString()}\t\t");
            display.Append($"{temp:00.00} F\t\t");

            if (precipitation_type != "NA")
            {
                display.Append($"{precipitationProbability:00.00} % chance of {precipitation_type.ToString().ReformatClimaCellString()}");
            }

            return display.ToString();
        }

        public string GetImagePath()
        {
            return FormattingUtilities.GetImagePath(weather_code.ToString(), weather_time.ToLocalTime());
        }

        public bool IsDailyLow
        {
            get;
            set;
        } = false;

        public bool IsDailyHigh
        {
            get;
            set;
        } = false;

        public bool AboveMedianTemp
        {
            get;
            set;
        } = false;

        public bool BelowDailyMedian
        {
            get;
            set;
        } = false;

        public string GetHighLowBackground()
        {
            if (IsDailyHigh)
            {
                return "#f29e66";
            }

            if (IsDailyLow)
            {
                return "#35d7f0";
            }

            if (BelowDailyMedian)
            {
                return "#aff0fa";
            }

            if (AboveMedianTemp)
            {
                return "#fcddb6";
            }

            return "#ffffff";
        }

        public string GetWeatherCodeDisplay()
        {
            return weather_code.ToString().ReformatClimaCellString();
        }

        public string ToCheapSingleTempJSON()
        {
            int hour =  weather_time.ToLocalTime().Hour;

            if (hour < 5)
            {
                hour += 24;
            }
            return $"[[{hour:D2},0,0,0],{temp}]";
        }

    }
}
