using System;
using System.Threading.Tasks;

using KissU.Dependency;
using KissU.CPlatform.Configurations;
using KissU.CPlatform.Configurations.Watch;

namespace KissU.CPlatform.Routing
{
    /// <summary>
    /// 服务路线监视.
    /// Implements the <see cref="ConfigurationWatch" />
    /// </summary>
    /// <seealso cref="ConfigurationWatch" />
    public class ServiceRouteWatch : ConfigurationWatch
    {
        private readonly Action _action;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceRouteWatch" /> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="action">The action.</param>
        public ServiceRouteWatch(CPlatformContainer serviceProvider, Action action)
        {
            _action = action;
            if (serviceProvider.IsRegistered<IConfigurationWatchManager>())
            {
                serviceProvider.GetInstances<IConfigurationWatchManager>().Register(this);
            }

            _action.Invoke();
        }

        /// <summary>
        /// 处理此实例.
        /// </summary>
        /// <returns>Task.</returns>
        public override async Task Process()
        {
            await Task.Run(_action);
        }
    }
}