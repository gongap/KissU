using System;

namespace KissU.Surging.CPlatform.Diagnostics
{
    /// <summary>
    /// SegmentSpan.
    /// </summary>
    public class SegmentSpan
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SegmentSpan" /> class.
        /// </summary>
        /// <param name="operationName">Name of the operation.</param>
        /// <param name="spanType">Type of the span.</param>
        public SegmentSpan(string operationName, SpanType spanType)
        {
            OperationName = new StringOrIntValue(operationName);
            SpanType = spanType;
        }

        /// <summary>
        /// Gets the span identifier.
        /// </summary>
        public int SpanId { get; } = 0;

        /// <summary>
        /// Gets the parent span identifier.
        /// </summary>
        public int ParentSpanId { get; } = -1;

        /// <summary>
        /// Gets the start time.
        /// </summary>
        public long StartTime { get; } = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        /// <summary>
        /// Gets the end time.
        /// </summary>
        public long EndTime { get; private set; }

        /// <summary>
        /// Gets the name of the operation.
        /// </summary>
        public StringOrIntValue OperationName { get; }

        /// <summary>
        /// Gets or sets the peer.
        /// </summary>
        public StringOrIntValue Peer { get; set; }

        /// <summary>
        /// Gets the type of the span.
        /// </summary>
        public SpanType SpanType { get; }

        /// <summary>
        /// Gets or sets the span layer.
        /// </summary>
        public SpanLayer SpanLayer { get; set; }

        /// <summary>
        /// Limiting values. Please see <see cref="Components" /> or see
        /// <seealso
        ///     href="https://github.com/apache/incubator-skywalking/blob/master/oap-server/server-starter/src/main/resources/component-libraries.yml" />
        /// </summary>
        public StringOrIntValue Component { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is error.
        /// </summary>
        public bool IsError { get; set; }

        /// <summary>
        /// Gets the tags.
        /// </summary>
        public TagCollection Tags { get; } = new TagCollection();

        /// <summary>
        /// Gets the logs.
        /// </summary>
        public LogCollection Logs { get; } = new LogCollection();

        /// <summary>
        /// Adds the tag.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns>SegmentSpan.</returns>
        public SegmentSpan AddTag(string key, string value)
        {
            Tags.AddTag(key, value);
            return this;
        }

        /// <summary>
        /// Adds the tag.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns>SegmentSpan.</returns>
        public SegmentSpan AddTag(string key, long value)
        {
            Tags.AddTag(key, value.ToString());
            return this;
        }

        /// <summary>
        /// Adds the tag.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">if set to <c>true</c> [value].</param>
        /// <returns>SegmentSpan.</returns>
        public SegmentSpan AddTag(string key, bool value)
        {
            Tags.AddTag(key, value.ToString());
            return this;
        }

        /// <summary>
        /// Adds the log.
        /// </summary>
        /// <param name="events">The events.</param>
        public void AddLog(params LogEvent[] events)
        {
            var log = new SpanLog(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(), events);
            Logs.AddLog(log);
        }

        /// <summary>
        /// Finishes this instance.
        /// </summary>
        public void Finish()
        {
            EndTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        }
    }
}