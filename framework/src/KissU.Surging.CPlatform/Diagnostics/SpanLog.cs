using System.Collections.Generic;
using System.Linq;

namespace KissU.Surging.CPlatform.Diagnostics
{
    /// <summary>
    /// SpanLog.
    /// </summary>
    public class SpanLog
    {
        private static readonly Dictionary<string, string> Empty = new Dictionary<string, string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="SpanLog" /> class.
        /// </summary>
        /// <param name="timestamp">The timestamp.</param>
        /// <param name="events">The events.</param>
        public SpanLog(long timestamp, params LogEvent[] events)
        {
            Timestamp = timestamp;
            Data = events?.ToDictionary(x => x.Key, x => x.Value) ?? Empty;
        }

        /// <summary>
        /// Gets the timestamp.
        /// </summary>
        public long Timestamp { get; }

        /// <summary>
        /// Gets the data.
        /// </summary>
        public IReadOnlyDictionary<string, string> Data { get; }
    }
}