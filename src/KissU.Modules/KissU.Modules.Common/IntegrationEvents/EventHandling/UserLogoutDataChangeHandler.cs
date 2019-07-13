using Surging.Core.CPlatform.EventBus.Events;
using Surging.Core.CPlatform.Utilities;
using Surging.Core.EventBusRabbitMQ.Attributes;
using KissU.IModuleServices.Common;
using KissU.IModuleServices.Common.Models;
using KissU.IModuleServices.Common.Models.Events;
using System;
using System.Threading.Tasks;

namespace Surging.Modules.Common.IntegrationEvents.EventHandling
{
    [QueueConsumer("UserLogoutDateChangeHandler")]
    public class UserLogoutDataChangeHandler : IIntegrationEventHandler<LogoutEvent>
    {
        private readonly IUserService _userService;
        public UserLogoutDataChangeHandler()
        {
            _userService = ServiceLocator.GetService<IUserService>("User");
        }
        public async Task Handle(LogoutEvent @event)
        {
            Console.WriteLine($"消费1。");
            await _userService.Update(int.Parse(@event.UserId), new UserModel()
            {

            });
            Console.WriteLine($"消费1失败。");
            throw new Exception();
        }
    }
}
