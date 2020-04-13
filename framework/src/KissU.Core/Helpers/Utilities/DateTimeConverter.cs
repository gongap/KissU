using System;

namespace KissU.Core.Helpers.Utilities
{
    /// <summary>
    /// 日期时间转换器.
    /// </summary>
    public class DateTimeConverter
    {
        /// <summary>
        /// 将时间标为Unix时间戳.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns>System.Int64.</returns>
        public static long DateTimeToUnixTimestamp(DateTime dateTime)
        {
            var start = new DateTime(1970, 1, 1, 0, 0, 0, dateTime.Kind);
            return Convert.ToInt64((dateTime - start).TotalSeconds);
        }

        /// <summary>
        /// Unix将时间戳记为日期时间.
        /// </summary>
        /// <param name="timestamp">The timestamp.</param>
        /// <param name="time">The time.</param>
        /// <returns>DateTime.</returns>
        public static DateTime UnixTimestampToDateTime(long timestamp, DateTime? time = null)
        {
            var start = time == null
                ? new DateTime(1970, 1, 1, 0, 0, 0)
                : new DateTime(1970, 1, 1, 0, 0, 0, time.Value.Kind);
            return start.AddSeconds(timestamp);
        }
    }
}