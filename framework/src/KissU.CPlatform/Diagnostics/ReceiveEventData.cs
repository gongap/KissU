using System;

namespace KissU.CPlatform.Diagnostics
{
    /// <summary>
    /// ReceiveEventData.
    /// Implements the <see cref="EventData" />
    /// </summary>
    /// <seealso cref="EventData" />
    public class ReceiveEventData : EventData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReceiveEventData" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public ReceiveEventData(DiagnosticMessage message)
            : base(Guid.Parse(message.Id))
        {
            Message = message;
        }

        /// <summary>
        /// Gets or sets the headers.
        /// </summary>
        public TracingHeaders Headers { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public DiagnosticMessage Message { get; set; }
    }
}