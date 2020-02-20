﻿using System;
using System.Threading.Tasks;
using KissU.Core.CPlatform.EventBus.Events;
using KissU.Core.CPlatform.Utilities;
using KissU.Core.EventBusRabbitMQ.Attributes;
using KissU.Modules.SampleA.Service.Contracts;
using KissU.Modules.SampleA.Service.Contracts.Dtos;
using KissU.Modules.SampleA.Service.Contracts.Events;

namespace KissU.Modules.SampleA.Service.EventHandlers
{
    /// <summary>
    /// UserLogoutDataChangeHandler.
    /// Implements the
    /// <see
    ///     cref="KissU.Core.CPlatform.EventBus.Events.IIntegrationEventHandler{KissU.Modules.SampleA.Service.Contracts.Events.LogoutEvent}" />
    /// </summary>
    /// <seealso
    ///     cref="KissU.Core.CPlatform.EventBus.Events.IIntegrationEventHandler{KissU.Modules.SampleA.Service.Contracts.Events.LogoutEvent}" />
    [QueueConsumer("UserLogoutDateChangeHandler")]
    public class UserLogoutDataChangeHandler : IIntegrationEventHandler<LogoutEvent>
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserLogoutDataChangeHandler" /> class.
        /// </summary>
        public UserLogoutDataChangeHandler()
        {
            _userService = ServiceLocator.GetService<IUserService>("User");
        }

        /// <summary>
        /// 处理.
        /// </summary>
        /// <param name="event">The event.</param>
        /// <returns>Task.</returns>
        /// <exception cref="System.Exception"></exception>
        public async Task Handle(LogoutEvent @event)
        {
            Console.WriteLine("消费1。");
            await _userService.Update(int.Parse(@event.UserId), new UserModel());
            Console.WriteLine("消费1失败。");
            throw new Exception();
        }
    }
}