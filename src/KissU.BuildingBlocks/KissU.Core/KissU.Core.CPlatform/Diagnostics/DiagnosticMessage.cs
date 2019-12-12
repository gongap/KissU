using KissU.Core.CPlatform.Messages;

namespace KissU.Core.CPlatform.Diagnostics
{
    public class DiagnosticMessage: TransportMessage
    {
        public string MessageName { get; set; }
    }
}
