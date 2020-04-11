using System;
using System.Threading.Tasks;
using KissU.Core.EventBus.Events;
using KissU.Core.Utilities;
using KissU.Surging.EventBusRabbitMQ;
using KissU.Surging.EventBusRabbitMQ.Attributes;
using KissU.Modules.SampleA.Service.Contracts;
using KissU.Modules.SampleA.Service.Contracts.Dtos;
using KissU.Modules.SampleA.Service.Contracts.Events;

namespace KissU.Modules.SampleA.Service.EventHandlers
{
    /// <summary>
    /// UserLoginDateChangeHandler.
    /// </summary>
    [QueueConsumer("UserLoginDateChangeHandler", QueueConsumerMode.Normal, QueueConsumerMode.Fail)]
    public class UserLoginDateChangeHandler : BaseIntegrationEventHandler<UserEvent>
    {
        private readonly IAccountService _accountService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserLoginDateChangeHandler" /> class.
        /// </summary>
        public UserLoginDateChangeHandler()
        {
            _accountService = ServiceLocator.GetService<IAccountService>("Account");
        }

        /// <summary>
        /// 处理.
        /// </summary>
        /// <param name="event">The event.</param>
        /// <returns>Task.</returns>
        /// <exception cref="System.Exception"></exception>
        public override async Task Handle(UserEvent @event)
        {
            Console.WriteLine("消费1。");
            await _accountService.Update(@event.UserId, new UserModel
            {
                Age = @event.Age,
                Name = @event.Name,
                UserId = @event.UserId
            });
            Console.WriteLine("消费1失败。");
            throw new Exception();
        }

        /// <summary>
        /// 已处理.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>A <see cref="T:System.Threading.Tasks.Task" /> representing the asynchronous operation.</returns>
        public override Task Handled(EventContext context)
        {
            Console.WriteLine($"调用{context.Count}次。类型:{context.Type}");
            var model = context.Content as UserEvent;
            return Task.CompletedTask;
        }
    }
}