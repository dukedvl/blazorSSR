using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HouseHubRazor.Utility
{
    public static class ExtensionMethods
    {
        public static bool IsNullOrEmpty(this string someString)
        {
            return string.IsNullOrEmpty(someString);
        }

        /// <summary>
        /// Condense Timespans into a short-form string (10d 3h 20m 10s)
        /// </summary>
        /// <param name="timeSpan"></param>
        /// <returns></returns>
        public static string GetCondensedTimeSpanString(this TimeSpan timeSpan)
        {
            StringBuilder response = new StringBuilder();

            if (timeSpan.Days > 0)
            {
                response.Append($"{timeSpan.Days}d ");
            }

            if (timeSpan.Hours > 0)
            {
                response.Append($"{timeSpan.Hours}h ");
            }

            if (timeSpan.Minutes > 0)
            {
                response.Append($"{timeSpan.Minutes}m ");
            }

            if (timeSpan.Seconds > 0)
            {
                response.Append($"{timeSpan.Seconds}s ");
            }

            return response.ToString();

        }

        /// <summary>
        /// Build Date
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static DateTime GetLinkerTime(this Assembly assembly, TimeZoneInfo target = null)
        {
            var filePath = assembly.Location;
            const int c_PeHeaderOffset = 60;
            const int c_LinkerTimestampOffset = 8;

            var buffer = new byte[2048];

            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                stream.Read(buffer, 0, 2048);

            var offset = BitConverter.ToInt32(buffer, c_PeHeaderOffset);
            var secondsSince1970 = BitConverter.ToInt32(buffer, offset + c_LinkerTimestampOffset);
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            var linkTimeUtc = epoch.AddSeconds(secondsSince1970);

            var tz = target ?? TimeZoneInfo.Local;
            var localTime = TimeZoneInfo.ConvertTimeFromUtc(linkTimeUtc, tz);

            return localTime;
        }

        public static string ShortWeekdayString(this DateTime value)
        {
            return $"{value.DayOfWeek.ToString().Substring(0, 3)} {value.Month}/{value.Day}";
        }
    }
}
