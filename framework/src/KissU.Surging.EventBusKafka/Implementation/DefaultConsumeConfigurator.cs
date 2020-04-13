using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using KissU.Core;
using KissU.Core.Dependency;
using KissU.Core.EventBus.Events;
using KissU.Core.EventBus.Implementation;
using KissU.Surging.EventBusKafka.Utilities;

namespace KissU.Surging.EventBusKafka.Implementation
{
    /// <summary>
    /// DefaultConsumeConfigurator.
    /// Implements the <see cref="KissU.Surging.EventBusKafka.IConsumeConfigurator" />
    /// </summary>
    /// <seealso cref="KissU.Surging.EventBusKafka.IConsumeConfigurator" />
    public class DefaultConsumeConfigurator : IConsumeConfigurator
    {
        private readonly CPlatformContainer _container;
        private readonly IEventBus _eventBus;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultConsumeConfigurator" /> class.
        /// </summary>
        /// <param name="eventBus">The event bus.</param>
        /// <param name="container">The container.</param>
        public DefaultConsumeConfigurator(IEventBus eventBus, CPlatformContainer container)
        {
            _eventBus = eventBus;
            _container = container;
        }

        /// <summary>
        /// Configures the specified consumers.
        /// </summary>
        /// <param name="consumers">The consumers.</param>
        public void Configure(List<Type> consumers)
        {
            foreach (var consumer in consumers)
            {
                if (consumer.GetTypeInfo().IsGenericType)
                {
                    continue;
                }

                var consumerType = consumer.GetInterfaces()
                    .Where(
                        d =>
                            d.GetTypeInfo().IsGenericType &&
                            d.GetGenericTypeDefinition() == typeof(IIntegrationEventHandler<>))
                    .Select(d => d.GetGenericArguments().Single())
                    .First();
                try
                {
                    var type = consumer;
                    this.FastInvoke(new[] {consumerType, consumer},
                        x => x.ConsumerTo<object, IIntegrationEventHandler<object>>());
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Unconfigures the specified consumers.
        /// </summary>
        /// <param name="consumers">The consumers.</param>
        public void Unconfigure(List<Type> consumers)
        {
            foreach (var consumer in consumers)
            {
                if (consumer.GetTypeInfo().IsGenericType)
                {
                    continue;
                }

                var consumerType = consumer.GetInterfaces()
                    .Where(
                        d =>
                            d.GetTypeInfo().IsGenericType &&
                            d.GetGenericTypeDefinition() == typeof(IIntegrationEventHandler<>))
                    .Select(d => d.GetGenericArguments().Single())
                    .First();
                try
                {
                    var type = consumer;
                    this.FastInvoke(new[] {consumerType, consumer},
                        x => x.RemoveConsumer<object, IIntegrationEventHandler<object>>());
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Consumers to.
        /// </summary>
        /// <typeparam name="TEvent">The type of the t event.</typeparam>
        /// <typeparam name="TConsumer">The type of the t consumer.</typeparam>
        protected void ConsumerTo<TEvent, TConsumer>()
            where TConsumer : IIntegrationEventHandler<TEvent>
            where TEvent : class
        {
            _eventBus.Subscribe<TEvent, TConsumer>
                (() => (TConsumer) _container.GetInstances(typeof(TConsumer)));
        }

        /// <summary>
        /// Removes the consumer.
        /// </summary>
        /// <typeparam name="TEvent">The type of the t event.</typeparam>
        /// <typeparam name="TConsumer">The type of the t consumer.</typeparam>
        protected void RemoveConsumer<TEvent, TConsumer>()
            where TConsumer : IIntegrationEventHandler<TEvent>
            where TEvent : class
        {
            _eventBus.Unsubscribe<TEvent, TConsumer>();
        }
    }
}