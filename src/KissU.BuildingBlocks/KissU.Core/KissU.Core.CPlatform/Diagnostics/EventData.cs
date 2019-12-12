using System;

namespace KissU.Core.CPlatform.Diagnostics
{
    public class EventData
    {
        public EventData(Guid operationId)
        {
            OperationId = operationId; 
        }

        public Guid OperationId { get; set; }

    }
}
