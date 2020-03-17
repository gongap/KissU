using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using KissU.Surging.CPlatform.DependencyResolution;
using KissU.Surging.CPlatform.EventBus;
using KissU.Surging.CPlatform.EventBus.Events;
using KissU.Surging.CPlatform.EventBus.Implementation;
using KissU.Surging.CPlatform.Utilities;
using KissU.Surging.EventBusRabbitMQ.Attributes;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Polly;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using RabbitMQ.Client.Framing;

namespace KissU.Surging.EventBusRabbitMQ.Implementation
{
    /// <summary>
    /// EventBusRabbitMQ.
    /// Implements the <see cref="KissU.Surging.CPlatform.EventBus.Implementation.IEventBus" />
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="KissU.Surging.CPlatform.EventBus.Implementation.IEventBus" />
    /// <seealso cref="System.IDisposable" />
    public class EventBusRabbitMQ : IEventBus, IDisposable
    {
        private readonly IDictionary<QueueConsumerMode, string> _exchanges;
        private readonly ILogger<EventBusRabbitMQ> _logger;
        private readonly int _messageTTL;
        private readonly IRabbitMQPersistentConnection _persistentConnection;
        private readonly ushort _prefetchCount;
        private readonly int _retryCount;
        private readonly int _rollbackCount;
        private readonly IEventBusSubscriptionsManager _subsManager;
        private readonly string BROKER_NAME;

        private readonly IDictionary<Tuple<string, QueueConsumerMode>, IModel> _consumerChannels;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventBusRabbitMQ" /> class.
        /// </summary>
        /// <param name="persistentConnection">The persistent connection.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="subsManager">The subs manager.</param>
        /// <exception cref="ArgumentNullException">persistentConnection</exception>
        /// <exception cref="ArgumentNullException">logger</exception>
        public EventBusRabbitMQ(IRabbitMQPersistentConnection persistentConnection, ILogger<EventBusRabbitMQ> logger,
            IEventBusSubscriptionsManager subsManager)
        {
            BROKER_NAME = AppConfig.BrokerName;
            _messageTTL = AppConfig.MessageTTL;
            _retryCount = AppConfig.RetryCount;
            _prefetchCount = AppConfig.PrefetchCount;
            _rollbackCount = AppConfig.FailCount;
            _consumerChannels = new Dictionary<Tuple<string, QueueConsumerMode>, IModel>();
            _exchanges = new Dictionary<QueueConsumerMode, string>();
            _exchanges.Add(QueueConsumerMode.Normal, BROKER_NAME);
            _exchanges.Add(QueueConsumerMode.Retry, $"{BROKER_NAME}@{QueueConsumerMode.Retry.ToString()}");
            _exchanges.Add(QueueConsumerMode.Fail, $"{BROKER_NAME}@{QueueConsumerMode.Fail.ToString()}");
            _persistentConnection =
                persistentConnection ?? throw new ArgumentNullException(nameof(persistentConnection));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _subsManager = subsManager ?? new InMemoryEventBusSubscriptionsManager();
            _persistentConnection.OnRabbitConnectionShutdown += PersistentConnection_OnEventShutDown;
            _subsManager.OnEventRemoved += SubsManager_OnEventRemoved;
        }

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public void Dispose()
        {
            foreach (var key in _consumerChannels.Keys)
            {
                if (_consumerChannels[key] != null)
                {
                    _consumerChannels[key].Dispose();
                }
            }

            _subsManager.Clear();
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
            if (!_persistentConnection.IsConnected)
            {
                _persistentConnection.TryConnect();
            }

            var policy = Policy.Handle<BrokerUnreachableException>()
                .Or<SocketException>()
                .WaitAndRetry(5, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                    (ex, time) => { _logger.LogWarning(ex.ToString()); });

            using (var channel = _persistentConnection.CreateModel())
            {
                var eventName = @event.GetType()
                    .Name;

                channel.ExchangeDeclare(BROKER_NAME,
                    "direct");
                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;
                var message = JsonConvert.SerializeObject(@event);
                var body = Encoding.UTF8.GetBytes(message);

                policy.Execute(() =>
                {
                    channel.BasicPublish(BROKER_NAME,
                        eventName,
                        properties,
                        body);
                });
            }
        }

        /// <summary>
        /// Subscribes the specified handler.
        /// </summary>
        /// <typeparam name="T">事件参数类型</typeparam>
        /// <typeparam name="TH">The type of the th.</typeparam>
        /// <param name="handler">The handler.</param>
        /// <exception cref="ArgumentNullException">QueueConsumerAttribute</exception>
        public void Subscribe<T, TH>(Func<TH> handler)
            where TH : IIntegrationEventHandler<T>
        {
            var eventName = typeof(T).Name;
            var queueConsumerAttr = typeof(TH).GetCustomAttribute<QueueConsumerAttribute>();
            if (queueConsumerAttr == null)
                throw new ArgumentNullException("QueueConsumerAttribute");
            var containsKey = _subsManager.HasSubscriptionsForEvent<T>();
            if (!containsKey)
            {
                if (!_persistentConnection.IsConnected)
                {
                    _persistentConnection.TryConnect();
                }

                var _modeNames = Enum.GetNames(typeof(QueueConsumerMode));

                using (var channel = _persistentConnection.CreateModel())
                {
                    foreach (var modeName in _modeNames)
                    {
                        var mode = Enum.Parse<QueueConsumerMode>(modeName);

                        var queueName = "";

                        if (mode != QueueConsumerMode.Normal)
                            queueName = $"{queueConsumerAttr.QueueName}@{mode.ToString()}";
                        else
                            queueName = queueConsumerAttr.QueueName;
                        var key = new Tuple<string, QueueConsumerMode>(queueName, mode);
                        if (_consumerChannels.ContainsKey(key))
                        {
                            _consumerChannels[key].Close();
                            _consumerChannels.Remove(key);
                        }

                        _consumerChannels.Add(key,
                            CreateConsumerChannel(queueConsumerAttr, eventName, mode));
                        channel.QueueBind(queueName,
                            _exchanges[mode],
                            eventName);
                    }
                }
            }

            if (!_subsManager.HasSubscriptionsForEvent<T>())
                _subsManager.AddSubscription<T, TH>(handler, queueConsumerAttr.QueueName);
        }

        /// <summary>
        /// Unsubscribes this instance.
        /// </summary>
        /// <typeparam name="T">事件参数类型</typeparam>
        /// <typeparam name="TH">The type of the th.</typeparam>
        public void Unsubscribe<T, TH>()
            where TH : IIntegrationEventHandler<T>
        {
            if (_subsManager.HasSubscriptionsForEvent<T>())
                _subsManager.RemoveSubscription<T, TH>();
        }

        private void SubsManager_OnEventRemoved(object sender, ValueTuple<string, string> tuple)
        {
            if (!_persistentConnection.IsConnected)
            {
                _persistentConnection.TryConnect();
            }

            using (var channel = _persistentConnection.CreateModel())
            {
                channel.QueueUnbind(tuple.Item1,
                    BROKER_NAME,
                    tuple.Item2);
            }
        }

        private static Func<IIntegrationEventHandler> FindHandlerByType(Type handlerType,
            IEnumerable<Func<IIntegrationEventHandler>> handlers)
        {
            foreach (var func in handlers)
            {
                if (func.GetMethodInfo().ReturnType == handlerType)
                {
                    return func;
                }
            }

            return null;
        }

        private IModel CreateConsumerChannel(QueueConsumerAttribute queueConsumer, string routeKey,
            QueueConsumerMode mode)
        {
            IModel result = null;
            switch (mode)
            {
                case QueueConsumerMode.Normal:
                {
                    var bindConsumer = queueConsumer.Modes.Any(p => p == QueueConsumerMode.Normal);
                    result = CreateConsumerChannel(queueConsumer.QueueName,
                        bindConsumer);
                }
                    break;
                case QueueConsumerMode.Retry:
                {
                    var bindConsumer = queueConsumer.Modes.Any(p => p == QueueConsumerMode.Retry);
                    result = CreateRetryConsumerChannel(queueConsumer.QueueName, routeKey,
                        bindConsumer);
                }
                    break;
                case QueueConsumerMode.Fail:
                {
                    var bindConsumer = queueConsumer.Modes.Any(p => p == QueueConsumerMode.Fail);
                    result = CreateFailConsumerChannel(queueConsumer.QueueName,
                        bindConsumer);
                }
                    break;
            }

            return result;
        }

        private IModel CreateConsumerChannel(string queueName, bool bindConsumer)
        {
            var mode = QueueConsumerMode.Normal;
            if (!_persistentConnection.IsConnected)
            {
                _persistentConnection.TryConnect();
            }

            var channel = _persistentConnection.CreateModel();

            channel.ExchangeDeclare(BROKER_NAME,
                "direct");

            channel.QueueDeclare(queueName, true, false, false, null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += async (model, ea) =>
            {
                var eventName = ea.RoutingKey;
                await ProcessEvent(eventName, ea.Body, mode, ea.BasicProperties);
                channel.BasicAck(ea.DeliveryTag, false);
            };
            if (bindConsumer)
            {
                channel.BasicQos(0, _prefetchCount, false);
                channel.BasicConsume(queueName,
                    false,
                    consumer);
                channel.CallbackException += (sender, ea) =>
                {
                    var key = new Tuple<string, QueueConsumerMode>(queueName, mode);
                    _consumerChannels[key].Dispose();
                    _consumerChannels[key] = CreateConsumerChannel(queueName, bindConsumer);
                };
            }
            else
                channel.Close();

            return channel;
        }

        private IModel CreateRetryConsumerChannel(string queueName, string routeKey, bool bindConsumer)
        {
            var mode = QueueConsumerMode.Retry;
            if (!_persistentConnection.IsConnected)
            {
                _persistentConnection.TryConnect();
            }

            IDictionary<string, object> arguments = new Dictionary<string, object>();
            arguments.Add("x-dead-letter-exchange", _exchanges[QueueConsumerMode.Fail]);
            arguments.Add("x-message-ttl", _messageTTL);
            arguments.Add("x-dead-letter-routing-key", routeKey);
            var channel = _persistentConnection.CreateModel();
            var retryQueueName = $"{queueName}@{mode.ToString()}";
            channel.ExchangeDeclare(_exchanges[mode],
                "direct");
            channel.QueueDeclare(retryQueueName, true, false, false, arguments);
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += async (model, ea) =>
            {
                var eventName = ea.RoutingKey;
                await ProcessEvent(eventName, ea.Body, mode, ea.BasicProperties);
                channel.BasicAck(ea.DeliveryTag, false);
            };
            if (bindConsumer)
            {
                channel.BasicQos(0, _prefetchCount, false);
                channel.BasicConsume(retryQueueName,
                    false,
                    consumer);
                channel.CallbackException += (sender, ea) =>
                {
                    var key = new Tuple<string, QueueConsumerMode>(queueName, mode);
                    _consumerChannels[key].Dispose();
                    _consumerChannels[key] = CreateRetryConsumerChannel(queueName, routeKey, bindConsumer);
                };
            }
            else
                channel.Close();


            return channel;
        }

        private IModel CreateFailConsumerChannel(string queueName, bool bindConsumer)
        {
            var mode = QueueConsumerMode.Fail;
            if (!_persistentConnection.IsConnected)
            {
                _persistentConnection.TryConnect();
            }

            var channel = _persistentConnection.CreateModel();
            channel.ExchangeDeclare(_exchanges[mode],
                "direct");
            var failQueueName = $"{queueName}@{mode.ToString()}";
            channel.QueueDeclare(failQueueName, true, false, false, null);
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += async (model, ea) =>
            {
                var eventName = ea.RoutingKey;
                await ProcessEvent(eventName, ea.Body, mode, ea.BasicProperties);
                channel.BasicAck(ea.DeliveryTag, false);
            };
            if (bindConsumer)
            {
                channel.BasicQos(0, _prefetchCount, false);
                channel.BasicConsume(failQueueName,
                    false,
                    consumer);
                channel.CallbackException += (sender, ea) =>
                {
                    var key = new Tuple<string, QueueConsumerMode>(queueName, mode);
                    _consumerChannels[key].Dispose();
                    _consumerChannels[key] = CreateFailConsumerChannel(queueName, bindConsumer);
                };
            }
            else
                channel.Close();

            return channel;
        }

        private async Task ProcessEvent(string eventName, byte[] body, QueueConsumerMode mode,
            IBasicProperties properties)
        {
            var message = Encoding.UTF8.GetString(body);
            if (_subsManager.HasSubscriptionsForEvent(eventName))
            {
                var eventType = _subsManager.GetEventTypeByName(eventName);
                var integrationEvent = JsonConvert.DeserializeObject(message, eventType);
                var handlers = _subsManager.GetHandlersForEvent(eventName);
                var concreteType = typeof(IIntegrationEventHandler<>).MakeGenericType(eventType);
                foreach (var handlerfactory in handlers)
                {
                    var handler = handlerfactory.DynamicInvoke();
                    long retryCount = 1;
                    try
                    {
                        var fastInvoker = GetHandler($"{concreteType.FullName}.Handle",
                            concreteType.GetMethod("Handle"));
                        await (Task) fastInvoker(handler, new[] {integrationEvent});
                    }
                    catch
                    {
                        if (!_persistentConnection.IsConnected)
                        {
                            _persistentConnection.TryConnect();
                        }

                        retryCount = GetRetryCount(properties);
                        using (var channel = _persistentConnection.CreateModel())
                        {
                            if (retryCount > _retryCount)
                            {
                                // 重试次数大于3次，则自动加入到死信队列
                                var rollbackCount = retryCount - _retryCount;
                                if (rollbackCount < _rollbackCount)
                                {
                                    IDictionary<string, object> headers = new Dictionary<string, object>();
                                    if (!headers.ContainsKey("x-orig-routing-key"))
                                        headers.Add("x-orig-routing-key", GetOrigRoutingKey(properties, eventName));
                                    retryCount = rollbackCount;
                                    channel.BasicPublish(_exchanges[QueueConsumerMode.Fail], eventName,
                                        CreateOverrideProperties(properties, headers), body);
                                }
                            }
                            else
                            {
                                var headers = properties.Headers;
                                if (headers == null)
                                {
                                    headers = new Dictionary<string, object>();
                                }

                                if (!headers.ContainsKey("x-orig-routing-key"))
                                    headers.Add("x-orig-routing-key", GetOrigRoutingKey(properties, eventName));
                                channel.BasicPublish(_exchanges[QueueConsumerMode.Retry], eventName,
                                    CreateOverrideProperties(properties, headers), body);
                            }
                        }
                    }
                    finally
                    {
                        var baseConcreteType = typeof(BaseIntegrationEventHandler<>).MakeGenericType(eventType);
                        if (handler.GetType().BaseType == baseConcreteType)
                        {
                            var context = new EventContext
                            {
                                Content = integrationEvent,
                                Count = retryCount,
                                Type = mode.ToString()
                            };
                            var fastInvoker = GetHandler($"{baseConcreteType.FullName}.Handled",
                                baseConcreteType.GetMethod("Handled"));
                            await (Task) fastInvoker(handler, new object[] {context});
                        }
                    }
                }
            }
        }

        private IBasicProperties CreateOverrideProperties(IBasicProperties properties,
            IDictionary<string, object> headers)
        {
            IBasicProperties newProperties = new BasicProperties();
            newProperties.ContentType = properties.ContentType ?? "";
            newProperties.ContentEncoding = properties.ContentEncoding ?? "";
            newProperties.Headers = properties.Headers;
            if (newProperties.Headers == null)
                newProperties.Headers = new Dictionary<string, object>();
            foreach (var key in headers.Keys)
            {
                if (!newProperties.Headers.ContainsKey(key))
                    newProperties.Headers.Add(key, headers[key]);
            }

            newProperties.DeliveryMode = properties.DeliveryMode;
            return newProperties;
        }

        private string GetOrigRoutingKey(IBasicProperties properties,
            string defaultValue)
        {
            var routingKey = defaultValue;
            if (properties != null)
            {
                var headers = properties.Headers;
                if (headers != null && headers.Count > 0)
                {
                    if (headers.ContainsKey("x-orig-routing-key"))
                    {
                        routingKey = headers["x-orig-routing-key"].ToString();
                    }
                }
            }

            return routingKey;
        }

        private long GetRetryCount(IBasicProperties properties)
        {
            var retryCount = 1L;
            try
            {
                if (properties != null)
                {
                    var headers = properties.Headers;
                    if (headers != null)
                    {
                        if (headers.ContainsKey("x-death"))
                        {
                            retryCount = GetRetryCount(properties, headers);
                        }
                        else
                        {
                            var death = new Dictionary<string, object>();
                            death.Add("count", retryCount);
                            headers.Add("x-death", death);
                        }
                    }
                }
            }
            catch
            {
            }

            return retryCount;
        }

        private long GetRetryCount(IBasicProperties properties, IDictionary<string, object> headers)
        {
            var retryCount = 1L;
            if (headers["x-death"] is List<object>)
            {
                var deaths = (List<object>) headers["x-death"];
                if (deaths.Count > 0)
                {
                    IDictionary<string, object> death = deaths[0] as Dictionary<string, object>;
                    retryCount = (long) death["count"];
                    death["count"] = ++retryCount;
                }
            }
            else
            {
                var death = (Dictionary<string, object>) headers["x-death"];
                if (death != null)
                {
                    retryCount = (long) death["count"];
                    death["count"] = ++retryCount;
                    properties.Headers = headers;
                }
            }

            return retryCount;
        }

        private FastInvoke.FastInvokeHandler GetHandler(string key, MethodInfo method)
        {
            var objInstance = ServiceResolver.Current.GetService(null, key);
            if (objInstance == null)
            {
                objInstance = FastInvoke.GetMethodInvoker(method);
                ServiceResolver.Current.Register(key, objInstance, null);
            }

            return objInstance as FastInvoke.FastInvokeHandler;
        }

        private void PersistentConnection_OnEventShutDown(object sender, ShutdownEventArgs reason)
        {
            OnShutdown(this, new EventArgs());
        }
    }
}