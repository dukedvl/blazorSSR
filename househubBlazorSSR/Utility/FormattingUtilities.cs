using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeatherForager
{
    public static class FormattingUtilities
    {
        public static string ReformatClimaCellString(this string snakeCase)
        {
            var spaces = snakeCase.Replace('_', ' ');
            var CapitalizeEachWord = spaces.Split(' ').ToList();

            var combined = CapitalizeEachWord.Select(s => char.ToUpperInvariant(s[0]) + s[1..]).Aggregate(string.Empty, (s1, s2) => $"{s1} {s2}");

            return combined;
        }

        //Don't know why this doesnt already exist
        public static char ToUpper(this char lowerCase)
        {
            return char.ToUpper(lowerCase);
        }

        public static string GetImagePath(string conditions, DateTime? time_of_day = null)
        {
            if (time_of_day == null)
            {
                //Default to noon, for mid-day forecasts
                time_of_day = new DateTime().AddHours(12);
            }

            conditions = conditions.ToLower();
            
            //6AM-6PM daytime
            bool dayTime = time_of_day.Value.Hour > 6 && time_of_day.Value.Hour < 18;


            if (conditions.Contains("partly") || conditions.Contains("mostly"))
            {
                return dayTime ? "img/011-sunny.png" : "img/013-full moon.png";
            }
            else if (conditions.Contains("cloud"))
            {
                return dayTime ? "img/002-cloud.png" : "img/013-full moon.png";
            }

            if (conditions.Contains("rain") || conditions.Contains("drizzle"))
            {
                return "img/004-rain.png";
            }

            if (conditions.Contains("fog"))
            {
                return dayTime ? "img/019-fog.png" : "img/029-full moon.png";
            }

            if (conditions.Contains("snow") || conditions.Contains("flurries"))
            {
                return "img/007-snow.png";
            }

            if (conditions.Contains("wind"))
            {
                return "img/012-windy.png";
            }

            if (conditions.Contains("hail"))
            {
                return "img/014-hail.png";
            }

            if (conditions.Contains("sleet"))
            {
                return "img/027-sleet.png";
            }

            if (conditions.Contains("storm"))
            {
                return "img/006-thunder.png";
            }
            return dayTime ? "img/001-sunny.png" : "img/008-full moon.png";
        }
    }
}
