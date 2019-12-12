﻿using System.Threading.Tasks;

namespace KissU.Core.CPlatform.EventBus.Events
{
    public interface IIntegrationEventHandler<in TIntegrationEvent> : IIntegrationEventHandler
    {
        Task Handle(TIntegrationEvent @event);
    }

    public abstract class BaseIntegrationEventHandler<TIntegrationEvent> : IIntegrationEventHandler<TIntegrationEvent>
    {
        public abstract Task Handle(TIntegrationEvent @event);

        public virtual  async  Task Handled(EventContext context)
        {
            await Task.CompletedTask;
        }
    }

    public interface IIntegrationEventHandler
    {
    }
}
