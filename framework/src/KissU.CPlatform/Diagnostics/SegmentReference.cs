namespace KissU.CPlatform.Diagnostics
{
    /// <summary>
    /// SegmentReference.
    /// </summary>
    public class SegmentReference
    {
        /// <summary>
        /// Gets or sets the reference.
        /// </summary>
        public Reference Reference { get; set; }

        /// <summary>
        /// Gets or sets the parent segment identifier.
        /// </summary>
        public UniqueId ParentSegmentId { get; set; }

        /// <summary>
        /// Gets or sets the parent span identifier.
        /// </summary>
        public int ParentSpanId { get; set; }

        /// <summary>
        /// Gets or sets the parent service instance identifier.
        /// </summary>
        public int ParentServiceInstanceId { get; set; }

        /// <summary>
        /// Gets or sets the entry service instance identifier.
        /// </summary>
        public int EntryServiceInstanceId { get; set; }

        /// <summary>
        /// Gets or sets the network address.
        /// </summary>
        public StringOrIntValue NetworkAddress { get; set; }

        /// <summary>
        /// Gets or sets the entry endpoint.
        /// </summary>
        public StringOrIntValue EntryEndpoint { get; set; }

        /// <summary>
        /// Gets or sets the parent endpoint.
        /// </summary>
        public StringOrIntValue ParentEndpoint { get; set; }
    }
}