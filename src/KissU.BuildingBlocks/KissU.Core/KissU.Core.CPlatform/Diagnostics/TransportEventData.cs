using System;

namespace KissU.Core.CPlatform.Diagnostics
{
    /// <summary>
    /// TransportEventData.
    /// Implements the <see cref="KissU.Core.CPlatform.Diagnostics.EventData" />
    /// </summary>
    /// <seealso cref="KissU.Core.CPlatform.Diagnostics.EventData" />
    public class TransportEventData : EventData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransportEventData"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="method">The method.</param>
        /// <param name="traceId">The trace identifier.</param>
        /// <param name="address">The address.</param>
        public TransportEventData(DiagnosticMessage message, string  method, string traceId, string address)
            : base(Guid.Parse(message.Id))
        {
            Message = message;
            RemoteAddress = address;
            Method = method;
            TraceId = traceId;
        }

        /// <summary>
        /// Gets or sets the trace identifier.
        /// </summary>
        public string TraceId { get; set; }

        /// <summary>
        /// Gets or sets the method.
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// Gets or sets the remote address.
        /// </summary>
        public string RemoteAddress { get; set; }

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
