using KissU.Core.CPlatform.Messages;

namespace KissU.Core.CPlatform.Diagnostics
{
    /// <summary>
    /// DiagnosticMessage.
    /// Implements the <see cref="KissU.Core.CPlatform.Messages.TransportMessage" />
    /// </summary>
    /// <seealso cref="KissU.Core.CPlatform.Messages.TransportMessage" />
    public class DiagnosticMessage: TransportMessage
    {
        /// <summary>
        /// Gets or sets the name of the message.
        /// </summary>
        public string MessageName { get; set; }
    }
}
