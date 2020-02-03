using System;

namespace KissU.Core.CPlatform.Diagnostics
{
    /// <summary>
    /// EventData.
    /// </summary>
    public class EventData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventData"/> class.
        /// </summary>
        /// <param name="operationId">The operation identifier.</param>
        public EventData(Guid operationId)
        {
            OperationId = operationId; 
        }

        /// <summary>
        /// Gets or sets the operation identifier.
        /// </summary>
        public Guid OperationId { get; set; }

    }
}
