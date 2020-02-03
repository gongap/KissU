using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissU.Core.CPlatform.Runtime.Server;
using KissU.Core.CPlatform.Support.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace KissU.Core.CPlatform.Support.Implementation
{
    /// <summary>
    /// 服务命令提供者.
    /// Implements the <see cref="ServiceCommandBase" />
    /// </summary>
    /// <seealso cref="ServiceCommandBase" />
    public class ServiceCommandProvider : ServiceCommandBase
    {
        private readonly ConcurrentDictionary<string, ServiceCommand> _serviceCommand =
            new ConcurrentDictionary<string, ServiceCommand>();

        private readonly IServiceEntryManager _serviceEntryManager;
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceCommandProvider" /> class.
        /// </summary>
        /// <param name="serviceEntryManager">The service entry manager.</param>
        /// <param name="serviceProvider">The service provider.</param>
        public ServiceCommandProvider(IServiceEntryManager serviceEntryManager, IServiceProvider serviceProvider)
        {
            _serviceEntryManager = serviceEntryManager;
            _serviceProvider = serviceProvider;
            var manager = serviceProvider.GetService<IServiceCommandManager>();
            if (manager != null)
            {
                manager.Changed += ServiceCommandManager_Removed;
                manager.Removed += ServiceCommandManager_Removed;
                manager.Created += ServiceCommandManager_Add;
            }
        }

        /// <summary>
        /// 获取命令.
        /// </summary>
        /// <param name="serviceId">The service identifier.</param>
        /// <returns>ValueTask&lt;ServiceCommand&gt;.</returns>
        public override async ValueTask<ServiceCommand> GetCommand(string serviceId)
        {
            var result = _serviceCommand.GetValueOrDefault(serviceId);
            if (result == null)
            {
                var task = GetCommandAsync(serviceId);
                return task.IsCompletedSuccessfully ? task.Result : await task;
            }

            return result;
        }

        /// <summary>
        /// 获取命令.
        /// </summary>
        /// <param name="serviceId">The service identifier.</param>
        /// <returns>Task&lt;ServiceCommand&gt;.</returns>
        public async Task<ServiceCommand> GetCommandAsync(string serviceId)
        {
            var result = new ServiceCommand();
            var manager = _serviceProvider.GetService<IServiceCommandManager>();
            if (manager == null)
            {
                var command = (from q in _serviceEntryManager.GetEntries()
                               let k = q.Attributes
                               where k.OfType<CommandAttribute>().Count() > 0 && q.Descriptor.Id == serviceId
                               select k.OfType<CommandAttribute>().FirstOrDefault()).FirstOrDefault();
                result = ConvertServiceCommand(command);
            }
            else
            {
                var commands = await manager.GetServiceCommandsAsync();
                result = ConvertServiceCommand(commands.Where(p => p.ServiceId == serviceId).FirstOrDefault());
            }

            _serviceCommand.AddOrUpdate(serviceId, result, (s, r) => result);
            return result;
        }

        private void ServiceCommandManager_Removed(object sender, ServiceCommandEventArgs e)
        {
            ServiceCommand value;
            _serviceCommand.TryRemove(e.Command.ServiceId, out value);
        }

        /// <summary>
        /// 处理ServiceCommandManager控件的Add事件.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ServiceCommandEventArgs" /> instance containing the event data.</param>
        public void ServiceCommandManager_Add(object sender, ServiceCommandEventArgs e)
        {
            _serviceCommand.GetOrAdd(e.Command.ServiceId, e.Command);
        }

        /// <summary>
        /// 转换服务命令.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>ServiceCommand.</returns>
        public ServiceCommand ConvertServiceCommand(CommandAttribute command)
        {
            var result = new ServiceCommand();
            if (command != null)
            {
                result = new ServiceCommand
                {
                    CircuitBreakerForceOpen = command.CircuitBreakerForceOpen,
                    ExecutionTimeoutInMilliseconds = command.ExecutionTimeoutInMilliseconds,
                    FailoverCluster = command.FailoverCluster,
                    Injection = command.Injection,
                    ShuntStrategy = command.ShuntStrategy,
                    RequestCacheEnabled = command.RequestCacheEnabled,
                    Strategy = command.Strategy,
                    InjectionNamespaces = command.InjectionNamespaces,
                    BreakeErrorThresholdPercentage = command.BreakeErrorThresholdPercentage,
                    BreakerForceClosed = command.BreakerForceClosed,
                    BreakerRequestVolumeThreshold = command.BreakerRequestVolumeThreshold,
                    BreakeSleepWindowInMilliseconds = command.BreakeSleepWindowInMilliseconds,
                    MaxConcurrentRequests = command.MaxConcurrentRequests,
                };
            }

            return result;
        }

        /// <summary>
        /// 转换服务命令.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>ServiceCommand.</returns>
        public ServiceCommand ConvertServiceCommand(ServiceCommandDescriptor command)
        {
            var result = new ServiceCommand();
            if (command != null)
            {
                result = new ServiceCommand
                {
                    CircuitBreakerForceOpen = command.CircuitBreakerForceOpen,
                    ExecutionTimeoutInMilliseconds = command.ExecutionTimeoutInMilliseconds,
                    FailoverCluster = command.FailoverCluster,
                    Injection = command.Injection,
                    RequestCacheEnabled = command.RequestCacheEnabled,
                    Strategy = command.Strategy,
                    ShuntStrategy = command.ShuntStrategy,
                    InjectionNamespaces = command.InjectionNamespaces,
                    BreakeErrorThresholdPercentage = command.BreakeErrorThresholdPercentage,
                    BreakerForceClosed = command.BreakerForceClosed,
                    BreakerRequestVolumeThreshold = command.BreakerRequestVolumeThreshold,
                    BreakeSleepWindowInMilliseconds = command.BreakeSleepWindowInMilliseconds,
                    MaxConcurrentRequests = command.MaxConcurrentRequests,
                };
            }

            return result;
        }
    }
}