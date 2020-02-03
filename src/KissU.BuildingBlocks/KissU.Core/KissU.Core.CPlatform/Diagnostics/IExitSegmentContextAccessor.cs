namespace KissU.Core.CPlatform.Diagnostics
{
    /// <summary>
    /// Interface IExitSegmentContextAccessor
    /// </summary>
    public interface IExitSegmentContextAccessor
    {
        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        SegmentContext Context { get; set; }
    }
}