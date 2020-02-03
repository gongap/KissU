using System;

namespace KissU.Core.CPlatform.Diagnostics
{
    /// <summary>
    /// TransportErrorEventData.
    /// Implements the <see cref="EventData" />
    /// </summary>
    /// <seealso cref="EventData" />
    public class TransportErrorEventData : EventData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransportErrorEventData" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="ex">The ex.</param>
        public TransportErrorEventData(DiagnosticMessage message, Exception ex)
            : base(Guid.Parse(message.Id))
        {
            Message = message;
            Exception = ex;
        }

        /// <summary>
        /// Gets or sets the exception.
        /// </summary>
        public Exception Exception { get; set; }

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