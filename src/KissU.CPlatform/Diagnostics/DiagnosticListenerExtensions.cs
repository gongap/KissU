using System.Diagnostics;

namespace KissU.CPlatform.Diagnostics
{
    /// <summary>
    /// 诊断侦听器扩展.
    /// </summary>
    public static class DiagnosticListenerExtensions
    {
        /// <summary>
        /// 诊断侦听器名称
        /// </summary>
        public const string DiagnosticListenerName = "KissU.{0}.DiagnosticListener";

        /// <summary>
        /// 前缀
        /// </summary>
        public const string Prefix = "KissU";        
        
        /// <summary>
        /// 开始传输
        /// </summary>
        public const string StartTransport = Prefix + ".{0}." + nameof(WriteTransportStart);

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

        #region MyRegion

        public const string StartRestTransport = Prefix + ".Rest." + nameof(WriteTransportStart);

        public const string BeforeRestTransport = Prefix + ".Rest." + nameof(WriteTransportBefore);

        public const string AfterRestTransport = Prefix + ".Rest." + nameof(WriteTransportAfter);

        public const string ErrorRestTransport = Prefix + ".Rest." + nameof(WriteTransportError);

        public const string StartRpcTransport = Prefix + ".Rpc." + nameof(WriteTransportStart);

        public const string BeforeRpcTransport = Prefix + ".Rpc." + nameof(WriteTransportBefore);

        public const string AfterRpcTransport = Prefix + ".Rpc." + nameof(WriteTransportAfter);

        public const string ErrorRpcTransport = Prefix + ".Rpc." + nameof(WriteTransportError);

        public const string StartMqttTransport = Prefix + ".Mqtt." + nameof(WriteTransportStart);

        public const string BeforeMqttTransport = Prefix + ".Mqtt." + nameof(WriteTransportBefore);

        public const string AfterMqttTransport = Prefix + ".Mqtt." + nameof(WriteTransportAfter);

        public const string ErrorMqttTransport = Prefix + ".Mqtt." + nameof(WriteTransportError);

        #endregion

        /// <summary>
        /// Writes the transport before.
        /// </summary>
        /// <param name="diagnosticListener">The diagnostic listener.</param>
        /// <param name="transportType">Type of the transport.</param>
        /// <param name="eventData">The event data.</param>
        public static void WriteTransportStart(this DiagnosticListener diagnosticListener, TransportType transportType,
            TransportEventData eventData)
        {
            if (diagnosticListener.IsEnabled(string.Format(StartTransport, transportType)))
            {
                eventData.Headers ??= new TracingHeaders();
                diagnosticListener.Write(string.Format(StartTransport, transportType), eventData);
            }
        }

        /// <summary>
        /// Writes the transport before.
        /// </summary>
        /// <param name="diagnosticListener">The diagnostic listener.</param>
        /// <param name="transportType">Type of the transport.</param>
        /// <param name="eventData">The event data.</param>
        public static void WriteTransportBefore(this DiagnosticListener diagnosticListener, TransportType transportType,
            TransportEventData eventData)
        {
            if (diagnosticListener.IsEnabled(string.Format(BeforeTransport, transportType)))
            {
                eventData.Headers ??= new TracingHeaders();
                diagnosticListener.Write(string.Format(BeforeTransport, transportType), eventData);
            }
        }

        /// <summary>
        /// Writes the transport after.
        /// </summary>
        /// <param name="diagnosticListener">The diagnostic listener.</param>
        /// <param name="transportType">Type of the transport.</param>
        /// <param name="eventData">The event data.</param>
        public static void WriteTransportAfter(this DiagnosticListener diagnosticListener, TransportType transportType,
            ReceiveEventData eventData)
        {
            if (diagnosticListener.IsEnabled(string.Format(AfterTransport, transportType)))
            {
                eventData.Headers ??= new TracingHeaders();
                diagnosticListener.Write(string.Format(AfterTransport, transportType), eventData);
            }
        }

        /// <summary>
        /// Writes the transport error.
        /// </summary>
        /// <param name="diagnosticListener">The diagnostic listener.</param>
        /// <param name="transportType">Type of the transport.</param>
        /// <param name="eventData">The event data.</param>
        public static void WriteTransportError(this DiagnosticListener diagnosticListener, TransportType transportType,
            TransportErrorEventData eventData)
        {
            if (diagnosticListener.IsEnabled(string.Format(ErrorTransport, transportType)))
            {
                eventData.Headers ??= new TracingHeaders();
                diagnosticListener.Write(string.Format(ErrorTransport, transportType), eventData);
            }
        }
    }
}
