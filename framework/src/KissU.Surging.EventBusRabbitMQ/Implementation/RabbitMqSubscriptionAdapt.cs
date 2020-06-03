using System;
using System.Collections.Generic;
using KissU.EventBus;
using KissU.EventBus.Events;

namespace KissU.Surging.EventBusRabbitMQ.Implementation
{
    /// <summary>
    /// RabbitMqSubscriptionAdapt.
    /// Implements the <see cref="ISubscriptionAdapt" />
    /// </summary>
    /// <seealso cref="ISubscriptionAdapt" />
    public class RabbitMqSubscriptionAdapt : ISubscriptionAdapt
    {
        private readonly IConsumeConfigurator _consumeConfigurator;
        private readonly IEnumerable<IIntegrationEventHandler> _integrationEventHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="RabbitMqSubscriptionAdapt" /> class.
        /// </summary>
        /// <param name="consumeConfigurator">The consume configurator.</param>
        /// <param name="integrationEventHandler">The integration event handler.</param>
        public RabbitMqSubscriptionAdapt(IConsumeConfigurator consumeConfigurator,
            IEnumerable<IIntegrationEventHandler> integrationEventHandler)
        {
            _consumeConfigurator = consumeConfigurator;
            _integrationEventHandler = integrationEventHandler;
        }

        /// <summary>
        /// 订阅.
        /// </summary>
        public void SubscribeAt()
        {
            _consumeConfigurator.Configure(GetQueueConsumers());
        }

        /// <summary>
        /// Unsubscribes this instance.
        /// </summary>
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