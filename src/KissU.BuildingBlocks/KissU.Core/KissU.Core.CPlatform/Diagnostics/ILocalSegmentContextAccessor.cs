namespace KissU.Core.CPlatform.Diagnostics
{
    /// <summary>
    /// Interface ILocalSegmentContextAccessor
    /// </summary>
    public interface ILocalSegmentContextAccessor
    {
        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        SegmentContext Context { get; set; }
    }
}
