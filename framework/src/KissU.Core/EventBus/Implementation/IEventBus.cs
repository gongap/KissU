using System;
using KissU.EventBus.Events;

namespace KissU.EventBus.Implementation
{
    /// <summary>
    /// 事件总线
    /// </summary>
    public interface IEventBus
    {
        /// <summary>
        /// Subscribes the specified handler.
        /// </summary>
        /// <typeparam name="T">事件参数类型</typeparam>
        /// <typeparam name="TH">The type of the th.</typeparam>
        /// <param name="handler">The handler.</param>
        void Subscribe<T, TH>(Func<TH> handler)
            where TH : IIntegrationEventHandler<T>;

        /// <summary>
        /// Unsubscribes this instance.
        /// </summary>
        /// <typeparam name="T">事件参数类型</typeparam>
        /// <typeparam name="TH">The type of the th.</typeparam>
        void Unsubscribe<T, TH>()
            where TH : IIntegrationEventHandler<T>;

        /// <summary>
        /// Publishes the specified event.
        /// </summary>
        /// <param name="event">The event.</param>
        void Publish(IntegrationEvent @event);

        /// <summary>
        /// Occurs when [on shutdown].
        /// </summary>
        event EventHandler OnShutdown;
    }
}