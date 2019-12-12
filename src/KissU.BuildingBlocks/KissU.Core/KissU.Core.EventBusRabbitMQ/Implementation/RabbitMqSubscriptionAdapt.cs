using System;
using System.Collections.Generic;
using KissU.Core.CPlatform.EventBus;
using KissU.Core.CPlatform.EventBus.Events;

namespace KissU.Core.EventBusRabbitMQ.Implementation
{
    public class RabbitMqSubscriptionAdapt : ISubscriptionAdapt
    {
        private readonly IConsumeConfigurator _consumeConfigurator;
        private readonly IEnumerable<IIntegrationEventHandler> _integrationEventHandler;
        public RabbitMqSubscriptionAdapt(IConsumeConfigurator consumeConfigurator, IEnumerable<IIntegrationEventHandler> integrationEventHandler)
        {
            this._consumeConfigurator = consumeConfigurator;
            this._integrationEventHandler = integrationEventHandler;
        }
    
        public void SubscribeAt()
        {
            _consumeConfigurator.Configure(GetQueueConsumers());
        }

       public void Unsubscribe()
        {
            _consumeConfigurator.Unconfigure(GetQueueConsumers());
        }


        #region 私有方法
        private List<Type> GetQueueConsumers()
        {
            var result = new List<Type>();
            foreach (var consumer in _integrationEventHandler)
            {
                var type = consumer.GetType();
                result.Add(type);
            }
            return result;
        }
        #endregion
    }
}
