using System.Threading.Tasks;

namespace KissU.Core.CPlatform.EventBus.Events
{
    /// <summary>
    /// 集成事件处理程序基类.
    /// Implements the <see cref="IIntegrationEventHandler{TIntegrationEvent}" />
    /// </summary>
    /// <typeparam name="TIntegrationEvent">The type of the t integration event.</typeparam>
    /// <seealso cref="IIntegrationEventHandler{TIntegrationEvent}" />
    public abstract class BaseIntegrationEventHandler<TIntegrationEvent> : IIntegrationEventHandler<TIntegrationEvent>
    {
        /// <summary>
        /// 处理.
        /// </summary>
        /// <param name="event">The event.</param>
        /// <returns>Task.</returns>
        public abstract Task Handle(TIntegrationEvent @event);

        /// <summary>
        /// 已处理.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public virtual async Task Handled(EventContext context)
        {
            await Task.CompletedTask;
        }
    }
}