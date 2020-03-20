using System;
using System.Threading.Tasks;
using Confluent.Kafka;
using KissU.Core;
using KissU.Core.EventBus;
using KissU.Core.EventBus.Events;
using KissU.Core.EventBus.Implementation;
using KissU.Surging.CPlatform;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Polly;

namespace KissU.Surging.EventBusKafka.Implementation
{
    /// <summary>
    /// EventBusKafka.
    /// Implements the <see cref="IEventBus" />
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="IEventBus" />
    /// <seealso cref="System.IDisposable" />
    public class EventBusKafka : IEventBus, IDisposable
    {
        private readonly IKafkaPersisterConnection _consumerConnection;
        private readonly ILogger<EventBusKafka> _logger;
        private readonly IKafkaPersisterConnection _producerConnection;
        private readonly IEventBusSubscriptionsManager _subsManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventBusKafka" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="subsManager">The subs manager.</param>
        /// <param name="serviceProvider">The service provider.</param>
        public EventBusKafka(ILogger<EventBusKafka> logger,
            IEventBusSubscriptionsManager subsManager,
            CPlatformContainer serviceProvider)
        {
            _logger = logger;
            _producerConnection =
                serviceProvider.GetInstances<IKafkaPersisterConnection>(KafkaConnectionType.Producer.ToString());
            _consumerConnection =
                serviceProvider.GetInstances<IKafkaPersisterConnection>(KafkaConnectionType.Consumer.ToString());
            _subsManager = subsManager;
            _subsManager.OnEventRemoved += SubsManager_OnEventRemoved;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _producerConnection.Dispose();
            _consumerConnection.Dispose();
        }

        /// <summary>
        /// Occurs when [on shutdown].
        /// </summary>
        public event EventHandler OnShutdown;

        /// <summary>
        /// Publishes the specified event.
        /// </summary>
        /// <param name="event">The event.</param>
        public void Publish(IntegrationEvent @event)
        {
            if (!_producerConnection.IsConnected)
            {
                _producerConnection.TryConnect();
            }

            var eventName = @event.GetType()
                .Name;
            var body = JsonConvert.SerializeObject(@event);
            var policy = Policy.Handle<KafkaException>()
                .WaitAndRetry(5, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                    (ex, time) => { _logger.LogWarning(ex.ToString()); });

            var conn = _producerConnection.CreateConnect() as Producer<Null, string>;
            policy.Execute(() => { conn.ProduceAsync(eventName, null, body).GetAwaiter().GetResult(); });
        }

        /// <summary>
        /// Subscribes the specified handler.
        /// </summary>
        /// <typeparam name="T">事件参数类型</typeparam>
        /// <typeparam name="TH">The type of the th.</typeparam>
        /// <param name="handler">The handler.</param>
        public void Subscribe<T, TH>(Func<TH> handler) where TH : IIntegrationEventHandler<T>
        {
            var eventName = typeof(T).Name;
            var containsKey = _subsManager.HasSubscriptionsForEvent<T>();
            if (!containsKey)
            {
                var channel = _consumerConnection.CreateConnect() as Consumer<Null, string>;
                channel.OnMessage += ConsumerClient_OnMessage;
                channel.Subscribe(eventName);
            }

            _subsManager.AddSubscription<T, TH>(handler, null);
        }

        /// <summary>
        /// Unsubscribes this instance.
        /// </summary>
        /// <typeparam name="T">事件参数类型</typeparam>
        /// <typeparam name="TH">The type of the th.</typeparam>
        public void Unsubscribe<T, TH>() where TH : IIntegrationEventHandler<T>
        {
            _subsManager.RemoveSubscription<T, TH>();
        }

        private void SubsManager_OnEventRemoved(object sender, ValueTuple<string, string> tuple)
        {
            if (!_consumerConnection.IsConnected)
            {
                _consumerConnection.TryConnect();
            }

            using (var channel = _consumerConnection.CreateConnect() as Consumer<Null, string>)
            {
                channel.Unsubscribe();
                if (_subsManager.IsEmpty)
                {
                    _consumerConnection.Dispose();
                }
            }
        }

        private void ConsumerClient_OnMessage(object sender, Message<Null, string> e)
        {
            ProcessEvent(e.Topic, e.Value).Wait();
        }

        private async Task ProcessEvent(string eventName, string message)
        {
            if (_subsManager.HasSubscriptionsForEvent(eventName))
            {
                var eventType = _subsManager.GetEventTypeByName(eventName);
                var integrationEvent = JsonConvert.DeserializeObject(message, eventType);
                var handlers = _subsManager.GetHandlersForEvent(eventName);

                foreach (var handlerfactory in handlers)
                {
                    try
                    {
                        var handler = handlerfactory.DynamicInvoke();
                        var concreteType = typeof(IIntegrationEventHandler<>).MakeGenericType(eventType);
                        await (Task) concreteType.GetMethod("Handle").Invoke(handler, new[] {integrationEvent});
                    }
                    catch
                    {
                    }
                }
            }
        }
    }
}