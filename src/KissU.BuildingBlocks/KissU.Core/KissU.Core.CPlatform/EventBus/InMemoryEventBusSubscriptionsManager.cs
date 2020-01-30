using System;
using System.Collections.Generic;
using System.Linq;
using KissU.Core.CPlatform.EventBus.Events;

namespace KissU.Core.CPlatform.EventBus
{
    /// <summary>
    /// 内存中事件总线订阅管理器.
    /// Implements the <see cref="IEventBusSubscriptionsManager" />
    /// </summary>
    /// <seealso cref="IEventBusSubscriptionsManager" />
    public class InMemoryEventBusSubscriptionsManager : IEventBusSubscriptionsManager
    {
        private readonly Dictionary<string, List<Delegate>> _handlers;
        private readonly Dictionary<Delegate, string> _consumers;
        private readonly List<Type> _eventTypes;

        /// <summary>
        /// Occurs when [on event removed].
        /// </summary>
        public event EventHandler<ValueTuple<string, string>> OnEventRemoved;

        /// <summary>
        /// Initializes a new instance of the <see cref="InMemoryEventBusSubscriptionsManager"/> class.
        /// </summary>
        public InMemoryEventBusSubscriptionsManager()
        {
            _handlers = new Dictionary<string, List<Delegate>>();
            _consumers = new Dictionary<Delegate, string>();
            _eventTypes = new List<Type>();
        }

        /// <summary>
        /// Gets a value indicating whether this instance is empty.
        /// </summary>
        public bool IsEmpty => !_handlers.Keys.Any();

        /// <summary>
        /// 清除.
        /// </summary>
        public void Clear() => _handlers.Clear();

        /// <summary>
        /// 添加订阅.
        /// </summary>
        /// <typeparam name="T">事件参数类型</typeparam>
        /// <typeparam name="TH">The type of the th.</typeparam>
        /// <param name="handler">The handler.</param>
        /// <param name="consumerName">Name of the consumer.</param>
        public void AddSubscription<T, TH>(Func<TH> handler,string consumerName)
            where TH : IIntegrationEventHandler<T>
        {
            var key = GetEventKey<T>();
            if (!HasSubscriptionsForEvent<T>())
            {
                _handlers.Add(key, new List<Delegate>());
            }

            _handlers[key].Add(handler);
            _consumers.Add(handler, consumerName);
            _eventTypes.Add(typeof(T));
        }

        /// <summary>
        /// 删除订阅.
        /// </summary>
        /// <typeparam name="T">事件参数类型</typeparam>
        /// <typeparam name="TH">The type of the th.</typeparam>
        public void RemoveSubscription<T, TH>()
            where TH : IIntegrationEventHandler<T>
        {
            var handlerToRemove = FindHandlerToRemove<T, TH>();
            if (handlerToRemove != null)
            {
                var key = GetEventKey<T>();
                var consumerName = _consumers[handlerToRemove];
                _handlers[key].Remove(handlerToRemove);
                if (!_handlers[key].Any())
                {
                    _handlers.Remove(key);
                    var eventType = _eventTypes.SingleOrDefault(e => e.Name == key);
                    if (eventType != null)
                    {
                        _eventTypes.Remove(eventType);
                        _consumers.Remove(handlerToRemove);
                        RaiseOnEventRemoved(eventType.Name,consumerName);
                    }
                }
            }
        }

        /// <summary>
        /// 获取事件的处理程序.
        /// </summary>
        /// <typeparam name="T">事件参数类型</typeparam>
        /// <returns>IEnumerable&lt;Delegate&gt;.</returns>
        public IEnumerable<Delegate> GetHandlersForEvent<T>()
            where T : IntegrationEvent
        {
            var key = GetEventKey<T>();
            return GetHandlersForEvent(key);
        }

        /// <summary>
        /// 获取事件的处理程序.
        /// </summary>
        /// <param name="eventName">Name of the event.</param>
        /// <returns>IEnumerable&lt;Delegate&gt;.</returns>
        public IEnumerable<Delegate> GetHandlersForEvent(string eventName) => _handlers[eventName];

        private void RaiseOnEventRemoved(string eventName,string consumerName)
        {
            var handler = OnEventRemoved;
            if (handler != null)
            {
                handler(this,new ValueTuple<string,string>(consumerName, eventName));
            }
        }

        private Delegate FindHandlerToRemove<T, TH>()
            where TH : IIntegrationEventHandler<T>
        {
            if (!HasSubscriptionsForEvent<T>())
            {
                return null;
            }

            var key = GetEventKey<T>();
            foreach (var func in _handlers[key])
            {
                var genericArgs = func.GetType().GetGenericArguments();
                if (genericArgs.SingleOrDefault() == typeof(TH))
                {
                    return func;
                }
            }

            return null;
        }

        /// <summary>
        /// Determines whether [has subscriptions for event].
        /// </summary>
        /// <typeparam name="T">事件参数类型</typeparam>
        /// <returns><c>true</c> if [has subscriptions for event]; otherwise, <c>false</c>.</returns>
        public bool HasSubscriptionsForEvent<T>()
        {
            var key = GetEventKey<T>();
            return HasSubscriptionsForEvent(key);
        }

        /// <summary>
        /// Determines whether [has subscriptions for event] [the specified event name].
        /// </summary>
        /// <param name="eventName">Name of the event.</param>
        /// <returns><c>true</c> if [has subscriptions for event] [the specified event name]; otherwise, <c>false</c>.</returns>
        public bool HasSubscriptionsForEvent(string eventName) => _handlers.ContainsKey(eventName);

        /// <summary>
        /// 通过名称获取事件类型.
        /// </summary>
        /// <param name="eventName">Name of the event.</param>
        /// <returns>Type.</returns>
        public Type GetEventTypeByName(string eventName) => _eventTypes.Single(t => t.Name == eventName);

        private string GetEventKey<T>()
        {
            return typeof(T).Name;
        }
    }
}