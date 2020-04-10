using System.Threading.Tasks;
using KissU.Core.Events.Handlers;
using KissU.Util.Events.Default;
using KissU.Util.Tests.Samples;
using NSubstitute;
using Xunit;

namespace KissU.Util.Tests.Events
{
    /// <summary>
    /// 事件总线测试
    /// </summary>
    public class EventBusTest
    {
        /// <summary>
        /// 测试初始化
        /// </summary>
        public EventBusTest()
        {
            _handler = Substitute.For<IEventHandler<EventSample>>();
        }

        /// <summary>
        /// 事件处理器
        /// </summary>
        private readonly IEventHandler<EventSample> _handler;

        /// <summary>
        /// 测试发布事件
        /// </summary>
        [Fact]
        public async Task TestPublish()
        {
            var manager = new EventHandlerManagerSample(_handler);
            var eventBus = new EventBus(manager);
            var @event = new EventSample {Name = "a"};
            await eventBus.PublishAsync(@event);
            await _handler.Received(1).HandleAsync(@event);
        }
    }
}