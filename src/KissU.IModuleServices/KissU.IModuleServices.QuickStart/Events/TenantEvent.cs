using Surging.Core.CPlatform.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace KissU.IntegrationEvents.QuickStart
{
    public class TenantEvent : IntegrationEvent
    {
        public string TenantId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }
    }
}
