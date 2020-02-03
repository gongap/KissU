namespace KissU.Core.CPlatform.Diagnostics
{
    /// <summary>
    /// Interface IEntrySegmentContextAccessor
    /// </summary>
    public interface IEntrySegmentContextAccessor
    {
        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        SegmentContext Context { get; set; }
    }
}