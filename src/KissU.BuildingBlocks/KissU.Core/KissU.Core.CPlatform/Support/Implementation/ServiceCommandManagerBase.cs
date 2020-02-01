using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissU.Core.CPlatform.Runtime.Server;
using KissU.Core.CPlatform.Serialization;
using KissU.Core.CPlatform.Support.Attributes;

namespace KissU.Core.CPlatform.Support.Implementation
{
    /// <summary>
    /// 服务命令管理器基类.
    /// Implements the <see cref="IServiceCommandManager" />
    /// </summary>
    /// <seealso cref="IServiceCommandManager" />
    public abstract class ServiceCommandManagerBase : IServiceCommandManager
    {
        private readonly ISerializer<string> _serializer;
        private readonly IServiceEntryManager _serviceEntryManager;
        private EventHandler<ServiceCommandEventArgs> _created;
        private EventHandler<ServiceCommandEventArgs> _removed;
        private EventHandler<ServiceCommandChangedEventArgs> _changed;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceCommandManagerBase"/> class.
        /// </summary>
        /// <param name="serializer">The serializer.</param>
        /// <param name="serviceEntryManager">The service entry manager.</param>
        protected ServiceCommandManagerBase(ISerializer<string> serializer, IServiceEntryManager serviceEntryManager)
        {
            _serializer = serializer;
            _serviceEntryManager = serviceEntryManager;
        }

        /// <summary>
        /// 服务命令被创建。
        /// </summary>
        public event EventHandler<ServiceCommandEventArgs> Created
        {
            add { _created += value; }
            remove { _created -= value; }
        }

        /// <summary>
        /// 服务命令被删除。
        /// </summary>
        public event EventHandler<ServiceCommandEventArgs> Removed
        {
            add { _removed += value; }
            remove { _removed -= value; }
        }

        /// <summary>
        /// 服务命令被修改。
        /// </summary>
        public event EventHandler<ServiceCommandChangedEventArgs> Changed
        {
            add { _changed += value; }
            remove { _changed -= value; }
        }

        /// <summary>
        /// 获取所有可用的服务命令信息。
        /// </summary>
        /// <returns>服务命令集合。</returns>
        public abstract Task<IEnumerable<ServiceCommandDescriptor>> GetServiceCommandsAsync();

        /// <summary>
        /// 初始化服务命令.
        /// </summary>
        /// <param name="routes">The routes.</param>
        /// <returns>Task.</returns>
        protected abstract Task InitServiceCommandsAsync(IEnumerable<ServiceCommandDescriptor> routes);

        /// <summary>
        /// 设置服务命令.
        /// </summary>
        /// <returns>Task.</returns>
        public virtual async Task SetServiceCommandsAsync()
        {
            List<ServiceCommandDescriptor> serviceCommands = new List<ServiceCommandDescriptor>();
            await Task.Run(() =>
            {
                var commands = (from q in _serviceEntryManager.GetEntries()
                                let k = q.Attributes
                                select new { ServiceId = q.Descriptor.Id, Command = k.OfType<CommandAttribute>().FirstOrDefault() }).ToList();
                commands.ForEach(command => serviceCommands.Add(ConvertServiceCommand(command.ServiceId, command.Command)));
                InitServiceCommandsAsync(serviceCommands);
            });
        }

        /// <summary>
        /// 清空所有的服务命令。
        /// </summary>
        /// <returns>一个任务。</returns>
        public abstract Task ClearAsync();

        /// <summary>
        /// 设置服务命令。
        /// </summary>
        /// <param name="routes">服务命令集合。</param>
        /// <returns>一个任务。</returns>
        public abstract Task SetServiceCommandsAsync(IEnumerable<ServiceCommandDescriptor> routes);

        /// <summary>
        /// Called when [created].
        /// </summary>
        /// <param name="args">The arguments.</param>
        protected void OnCreated(params ServiceCommandEventArgs[] args)
        {
            if (_created == null)
            {
                return;
            }

            foreach (var arg in args)
            {
                _created(this, arg);
            }
        }

        /// <summary>
        /// Called when [changed].
        /// </summary>
        /// <param name="args">The arguments.</param>
        protected void OnChanged(params ServiceCommandChangedEventArgs[] args)
        {
            if (_changed == null)
            {
                return;
            }

            foreach (var arg in args)
            {
                _changed(this, arg);
            }
        }

        /// <summary>
        /// Called when [removed].
        /// </summary>
        /// <param name="args">The arguments.</param>
        protected void OnRemoved(params ServiceCommandEventArgs[] args)
        {
            if (_removed == null)
            {
                return;
            }

            foreach (var arg in args)
            {
                _removed(this, arg);
            }
        }

        /// <summary>
        /// 转换服务命令.
        /// </summary>
        /// <param name="serviceId">The service identifier.</param>
        /// <param name="command">The command.</param>
        /// <returns>ServiceCommandDescriptor.</returns>
        private ServiceCommandDescriptor ConvertServiceCommand(string serviceId, CommandAttribute command)
        {
            var result = new ServiceCommandDescriptor() { ServiceId = serviceId };
            if (command != null)
            {
                result = new ServiceCommandDescriptor
                {
                    ServiceId = serviceId,
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