namespace KissU.Core.CPlatform.Diagnostics
{
    /// <summary>
    /// SegmentContext.
    /// </summary>
    public class SegmentContext
    {
        /// <summary>
        /// Gets the segment identifier.
        /// </summary>
        public UniqueId SegmentId { get; }

        /// <summary>
        /// Gets or sets the trace identifier.
        /// </summary>
        public UniqueId TraceId { get; set; }

        /// <summary>
        /// Gets the span.
        /// </summary>
        public SegmentSpan Span { get; }

        /// <summary>
        /// Gets the service identifier.
        /// </summary>
        public int ServiceId { get; }

        /// <summary>
        /// Gets the service instance identifier.
        /// </summary>
        public int ServiceInstanceId { get; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="SegmentContext"/> is sampled.
        /// </summary>
        public bool Sampled { get; }

        /// <summary>
        /// Gets a value indicating whether this instance is size limited.
        /// </summary>
        public bool IsSizeLimited { get; } = false;

        /// <summary>
        /// Gets the references.
        /// </summary>
        public SegmentReferenceCollection References { get; } = new SegmentReferenceCollection();

        /// <summary>
        /// Initializes a new instance of the <see cref="SegmentContext"/> class.
        /// </summary>
        /// <param name="traceId">The trace identifier.</param>
        /// <param name="segmentId">The segment identifier.</param>
        /// <param name="sampled">if set to <c>true</c> [sampled].</param>
        /// <param name="serviceId">The service identifier.</param>
        /// <param name="serviceInstanceId">The service instance identifier.</param>
        /// <param name="operationName">Name of the operation.</param>
        /// <param name="spanType">Type of the span.</param>
        public SegmentContext(UniqueId traceId, UniqueId segmentId, bool sampled, int serviceId, int serviceInstanceId, string operationName, SpanType spanType)
        {
            TraceId = traceId;
            Sampled = sampled;
            SegmentId = segmentId;
            ServiceId = serviceId;
            ServiceInstanceId = serviceInstanceId;
            Span = new SegmentSpan(operationName, spanType);
        }
    }
}