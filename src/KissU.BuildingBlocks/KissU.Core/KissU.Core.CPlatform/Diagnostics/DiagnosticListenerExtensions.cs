using System.Diagnostics;

namespace KissU.Core.CPlatform.Diagnostics
{
    /// <summary>
    /// 诊断侦听器扩展.
    /// </summary>
    public static class DiagnosticListenerExtensions
    {
        /// <summary>
        /// 诊断侦听器名称
        /// </summary>
        public const string DiagnosticListenerName = "KissUDiagnosticListener";

        /// <summary>
        /// 前缀
        /// </summary>
        public const string Prefix = "KissU.Core.";

        /// <summary>
        /// 传输前
        /// </summary>
        public const string BeforeTransport = Prefix + ".{0}." + nameof(WriteTransportBefore);

        /// <summary>
        /// 传输后
        /// </summary>
        public const string AfterTransport = Prefix + ".{0}." + nameof(WriteTransportAfter);

        /// <summary>
        /// 错误传输
        /// </summary>
        public const string ErrorTransport = Prefix + ".{0}." + nameof(WriteTransportError);

        /// <summary>
        /// Writes the transport before.
        /// </summary>
        /// <param name="diagnosticListener">The diagnostic listener.</param>
        /// <param name="transportType">Type of the transport.</param>
        /// <param name="eventData">The event data.</param>
        public static void WriteTransportBefore(this DiagnosticListener diagnosticListener, TransportType transportType, TransportEventData eventData)
        {
            if (diagnosticListener.IsEnabled(BeforeTransport))
            {
                eventData.Headers = new TracingHeaders();
                diagnosticListener.Write(string.Format(BeforeTransport, transportType), eventData);
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
            if (diagnosticListener.IsEnabled(AfterTransport))
            {
                eventData.Headers = new TracingHeaders();
                diagnosticListener.Write(string.Format(AfterTransport, transportType), eventData);
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
            if (diagnosticListener.IsEnabled(ErrorTransport))
            {
                eventData.Headers = new TracingHeaders();
                diagnosticListener.Write(string.Format(ErrorTransport, transportType), eventData);
            }
        }
    }
}