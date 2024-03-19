using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForager
{
    public static class DateUtilities
    {

        public static DateTime GetEndDateTime()
        {

            return DateTime.Now.AddDays(1);
        }

        public static string GetEndDateUTCString()
        {
            return GetEndDateTime().ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssK");
        }

        public static string GetWeekDateTime(int daysFromNow=7)
        {
            DateTime today = DateTime.Now;

            return today.AddDays(daysFromNow).ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssK");
        }
    }
}
