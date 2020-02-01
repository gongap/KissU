using System;

namespace KissU.Core.CPlatform.Utilities
{
    /// <summary>
    /// DateTimeConverter.
    /// </summary>
    public class DateTimeConverter
    {
        /// <summary>
        /// Dates the time to unix timestamp.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns>System.Int64.</returns>
        public static long DateTimeToUnixTimestamp( DateTime dateTime)
        {
            var start = new DateTime(1970, 1, 1, 0, 0, 0, dateTime.Kind);
            return Convert.ToInt64((dateTime - start).TotalSeconds);
        }

        /// <summary>
        /// Unixes the timestamp to date time.
        /// </summary>
        /// <param name="timestamp">The timestamp.</param>
        /// <param name="time">The time.</param>
        /// <returns>DateTime.</returns>
        public static DateTime UnixTimestampToDateTime( long timestamp, DateTime? time=null)
        {
            var start = time ==null?new DateTime(1970, 1, 1, 0, 0, 0): new DateTime(1970, 1, 1, 0, 0, 0,time.Value.Kind);
            return start.AddSeconds(timestamp);
        }
    }
}
