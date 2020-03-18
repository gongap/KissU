using System.Threading.Tasks;

namespace KissU.Surging.CPlatform.EventBus.Events
{
    /// <summary>
    /// 集成事件处理程序
    /// Implements the <see cref="IIntegrationEventHandler" />
    /// </summary>
    /// <typeparam name="TIntegrationEvent">The type of the t integration event.</typeparam>
    /// <seealso cref="IIntegrationEventHandler" />
    public interface IIntegrationEventHandler<in TIntegrationEvent> : IIntegrationEventHandler
    {
        /// <summary>
        /// 处理.
        /// </summary>
        /// <param name="event">The event.</param>
        /// <returns>Task.</returns>
        Task Handle(TIntegrationEvent @event);
    }

    /// <summary>
    /// 集成事件处理程序
    /// Implements the <see cref="IIntegrationEventHandler" />
    /// </summary>
    /// <seealso cref="IIntegrationEventHandler" />
    public interface IIntegrationEventHandler
    {
    }
}