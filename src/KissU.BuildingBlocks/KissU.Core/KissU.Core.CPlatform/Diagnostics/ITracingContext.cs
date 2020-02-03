namespace KissU.Core.CPlatform.Diagnostics
{
    /// <summary>
    /// Interface ITracingContext
    /// </summary>
    public interface ITracingContext
    {
        /// <summary>
        /// Creates the entry segment context.
        /// </summary>
        /// <param name="operationName">Name of the operation.</param>
        /// <param name="carrierHeader">The carrier header.</param>
        /// <returns>SegmentContext.</returns>
        SegmentContext CreateEntrySegmentContext(string operationName, ICarrierHeaderCollection carrierHeader);

        /// <summary>
        /// Creates the local segment context.
        /// </summary>
        /// <param name="operationName">Name of the operation.</param>
        /// <returns>SegmentContext.</returns>
        SegmentContext CreateLocalSegmentContext(string operationName);

        /// <summary>
        /// Creates the exit segment context.
        /// </summary>
        /// <param name="operationName">Name of the operation.</param>
        /// <param name="networkAddress">The network address.</param>
        /// <param name="carrierHeader">The carrier header.</param>
        /// <returns>SegmentContext.</returns>
        SegmentContext CreateExitSegmentContext(string operationName, string networkAddress, ICarrierHeaderCollection carrierHeader = default(ICarrierHeaderCollection));

        /// <summary>
        /// Releases the specified segment context.
        /// </summary>
        /// <param name="segmentContext">The segment context.</param>
        void Release(SegmentContext segmentContext);
    }
}