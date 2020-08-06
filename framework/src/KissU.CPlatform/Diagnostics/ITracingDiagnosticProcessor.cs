namespace KissU.CPlatform.Diagnostics
{
    /// <summary>
    /// Interface ITracingDiagnosticProcessor
    /// </summary>
    public interface ITracingDiagnosticProcessor
    {
        /// <summary>
        /// Gets the name of the listener.
        /// </summary>
        string ListenerName { get; }
    }
}