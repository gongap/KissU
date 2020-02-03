using System.Diagnostics;

namespace KissU.Core.CPlatform.Diagnostics
{
    /// <summary>
    /// DiagnosticListenerExtensions.
    /// </summary>
    public static class DiagnosticListenerExtensions
    {
        /// <summary>
        /// The diagnostic listener name
        /// </summary>
        public const string DiagnosticListenerName = "KissUDiagnosticListener";
        /// <summary>
        /// The prefix
        /// </summary>
        public const string Prefix = "KissU.Core.";
        /// <summary>
        /// The kiss u before transport
        /// </summary>
        public const string KissUBeforeTransport = Prefix +".{0}."+ nameof(WriteTransportBefore);
        /// <summary>
        /// The kiss u after transport
        /// </summary>
        public const string KissUAfterTransport= Prefix + ".{0}." + nameof(WriteTransportAfter);
        /// <summary>
        /// The kiss u error transport
        /// </summary>
        public const string KissUErrorTransport = Prefix + ".{0}." + nameof(WriteTransportError);

        /// <summary>
        /// Writes the transport before.
        /// </summary>
        /// <param name="diagnosticListener">The diagnostic listener.</param>
        /// <param name="transportType">Type of the transport.</param>
        /// <param name="eventData">The event data.</param>
        public static void WriteTransportBefore(this DiagnosticListener diagnosticListener,TransportType transportType, TransportEventData eventData)
        {

            if (diagnosticListener.IsEnabled(KissUBeforeTransport))
            {
                eventData.Headers = new TracingHeaders();
                diagnosticListener.Write(string.Format(KissUBeforeTransport,transportType), eventData);

            }
        }

        /// <summary>
        /// Writes the transport after.
        /// </summary>
        /// <param name="diagnosticListener">The diagnostic listener.</param>
        /// <param name="transportType">Type of the transport.</param>
        /// <param name="eventData">The event data.</param>
        public static void WriteTransportAfter(this DiagnosticListener diagnosticListener, TransportType transportType, ReceiveEventData eventData)
        { 
            if (diagnosticListener.IsEnabled(KissUAfterTransport))
            {
                eventData.Headers = new TracingHeaders();
                diagnosticListener.Write(string.Format(KissUAfterTransport, transportType), eventData);
            }
        }

        /// <summary>
        /// Writes the transport error.
        /// </summary>
        /// <param name="diagnosticListener">The diagnostic listener.</param>
        /// <param name="transportType">Type of the transport.</param>
        /// <param name="eventData">The event data.</param>
        public static void WriteTransportError(this DiagnosticListener diagnosticListener, TransportType transportType, TransportErrorEventData eventData)
        {
            if (diagnosticListener.IsEnabled(KissUErrorTransport))
            {
                eventData.Headers = new TracingHeaders();
                diagnosticListener.Write(string.Format(KissUErrorTransport, transportType), eventData);
            }
        }
    }
}
