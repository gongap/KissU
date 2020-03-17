using System;
using System.Collections.Generic;
using KissU.Surging.CPlatform.EventBus.Events;

namespace KissU.Surging.CPlatform.EventBus
{
    /// <summary>
    /// 事件总线订阅管理器
    /// </summary>
    public interface IEventBusSubscriptionsManager
    {
        /// <summary>
        /// Gets a value indicating whether this instance is empty.
        /// </summary>
        bool IsEmpty { get; }

        /// <summary>
        /// Occurs when [on event removed].
        /// </summary>
        event EventHandler<ValueTuple<string, string>> OnEventRemoved;

        /// <summary>
        /// Adds the subscription.
        /// </summary>
        /// <typeparam name="T">事件参数类型</typeparam>
        /// <typeparam name="TH">The type of the th.</typeparam>
        /// <param name="handler">The handler.</param>
        /// <param name="consumerName">Name of the consumer.</param>
        void AddSubscription<T, TH>(Func<TH> handler, string consumerName)
            where TH : IIntegrationEventHandler<T>;

        /// <summary>
        /// Removes the subscription.
        /// </summary>
        /// <typeparam name="T">事件参数类型</typeparam>
        /// <typeparam name="TH">The type of the th.</typeparam>
        void RemoveSubscription<T, TH>()
            where TH : IIntegrationEventHandler<T>;

        /// <summary>
        /// Determines whether [has subscriptions for event].
        /// </summary>
        /// <typeparam name="T">事件参数类型</typeparam>
        /// <returns><c>true</c> if [has subscriptions for event]; otherwise, <c>false</c>.</returns>
        bool HasSubscriptionsForEvent<T>();

        /// <summary>
        /// Determines whether [has subscriptions for event] [the specified event name].
        /// </summary>
        /// <param name="eventName">Name of the event.</param>
        /// <returns><c>true</c> if [has subscriptions for event] [the specified event name]; otherwise, <c>false</c>.</returns>
        bool HasSubscriptionsForEvent(string eventName);

        /// <summary>
        /// 通过名称获取事件类型.
        /// </summary>
        /// <param name="eventName">Name of the event.</param>
        /// <returns>Type.</returns>
        Type GetEventTypeByName(string eventName);

        /// <summary>
        /// 清除.
        /// </summary>
        void Clear();

        /// <summary>
        /// 获取事件的处理程序.
        /// </summary>
        /// <typeparam name="T">事件参数类型</typeparam>
        /// <returns>IEnumerable&lt;Delegate&gt;.</returns>
        IEnumerable<Delegate> GetHandlersForEvent<T>()
            where T : IntegrationEvent;

        /// <summary>
        /// 获取事件的处理程序.
        /// </summary>
        /// <param name="eventName">Name of the event.</param>
        /// <returns>IEnumerable&lt;Delegate&gt;.</returns>
        IEnumerable<Delegate> GetHandlersForEvent(string eventName);
    }
}