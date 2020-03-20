using System.Collections.Generic;
using KissU.Core.Events;
using KissU.Core.Events.Handlers;
using KissU.Core.Helpers;

namespace KissU.Util.Events.Default
{
    /// <summary>
    /// 事件处理器服务
    /// </summary>
    public class EventHandlerManager : IEventHandlerManager
    {
        /// <summary>
        /// 获取事件处理器列表
        /// </summary>
        /// <typeparam name="TEvent">事件类型</typeparam>
        /// <returns>List&lt;IEventHandler&lt;TEvent&gt;&gt;.</returns>
        public List<IEventHandler<TEvent>> GetHandlers<TEvent>() where TEvent : IEvent
        {
            return Ioc.CreateList<IEventHandler<TEvent>>();
        }
    }
}