using System;
using KissU.Core.CPlatform.EventBus.Events;

namespace KissU.Core.CPlatform.EventBus.Implementation
{
   public interface IEventBus
    {
        void Subscribe<T, TH>(Func<TH> handler)
            where TH : IIntegrationEventHandler<T>;
        void Unsubscribe<T, TH>()
            where TH : IIntegrationEventHandler<T>;

        void Publish(IntegrationEvent @event);

        event EventHandler OnShutdown;
    }
}
