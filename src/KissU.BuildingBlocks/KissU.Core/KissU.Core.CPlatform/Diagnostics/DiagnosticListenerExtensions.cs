using System.Diagnostics;

namespace KissU.Core.CPlatform.Diagnostics
{
    public static class DiagnosticListenerExtensions
    {
        public const string DiagnosticListenerName = "KissUDiagnosticListener";
        public const string Prefix = "KissU.Core.";
        public const string KissUBeforeTransport = Prefix +".{0}."+ nameof(WriteTransportBefore);
        public const string KissUAfterTransport= Prefix + ".{0}." + nameof(WriteTransportAfter);
        public const string KissUErrorTransport = Prefix + ".{0}." + nameof(WriteTransportError);

        public static void WriteTransportBefore(this DiagnosticListener diagnosticListener,TransportType transportType, TransportEventData eventData)
        {

            if (diagnosticListener.IsEnabled(KissUBeforeTransport))
            {
                eventData.Headers = new TracingHeaders();
                diagnosticListener.Write(string.Format(KissUBeforeTransport,transportType), eventData);

            }
        }

        public static void WriteTransportAfter(this DiagnosticListener diagnosticListener, TransportType transportType, ReceiveEventData eventData)
        { 
            if (diagnosticListener.IsEnabled(KissUAfterTransport))
            {
                eventData.Headers = new TracingHeaders();
                diagnosticListener.Write(string.Format(KissUAfterTransport, transportType), eventData);
            }
        }

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
