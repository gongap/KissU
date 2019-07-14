using Surging.Core.CPlatform.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Surging.Core.CPlatform.Utilities;
using Surging.Core.EventBusRabbitMQ.Attributes;
using Surging.Core.EventBusRabbitMQ;
using KissU.IModuleServices.QuickStart;
using KissU.IModuleServices.QuickStart.Dtos;
using KissU.IntegrationEvents.QuickStart;

namespace KissU.Modules.QuickStart.Application.IntegrationEvents.EventHandling
{
    [QueueConsumer("TenantCreatedHandler")]
    public  class TenantCreatedHandler : BaseIntegrationEventHandler<TenantEvent>
    {
        private readonly ITenantService _tenantService;
        public TenantCreatedHandler()
        {
            _tenantService = ServiceLocator.GetService<ITenantService>();
        }
        public override async Task Handle(TenantEvent @event)
        {
            Console.WriteLine($"消费TenantEvent");
           var entity= await _tenantService.GetById(@event.TenantId);
            var request = new TenantUpdateRequest() {
                Id= entity.Id,
                Code = "TenantCreatedHandler" + entity.Code,
                Name = entity.Name,
                Version = entity.Version
            };
            await _tenantService.Update(request);
            //throw new Exception();
        }

        public override Task Handled(EventContext context)
        {
            Console.WriteLine($"调用{context.Count}次。类型:{context.Type}");
            var model = context.Content as TenantEvent;
            return Task.CompletedTask;
        }
    }
}
