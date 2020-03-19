using System.Collections.Generic;

namespace KissU.Util.Events.Handlers
{
    /// <summary>
    /// 事件处理器服务
    /// </summary>
    public interface IEventHandlerManager
    {
        /// <summary>
        /// 获取事件处理器列表
        /// </summary>
        /// <typeparam name="TEvent">事件类型</typeparam>
        /// <returns>List&lt;IEventHandler&lt;TEvent&gt;&gt;.</returns>
        List<IEventHandler<TEvent>> GetHandlers<TEvent>() where TEvent : IEvent;
    }
}