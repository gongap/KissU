using System;
using System.Threading.Tasks;
using KissU.Core.CPlatform.Configurations;
using KissU.Core.CPlatform.Configurations.Watch;

namespace KissU.Core.CPlatform.Routing
{
    public class ServiceRouteWatch : ConfigurationWatch
    {
        private readonly Action _action;
        public ServiceRouteWatch(CPlatformContainer serviceProvider,  Action action)
        {
            this._action = action;
            if (serviceProvider.IsRegistered<IConfigurationWatchManager>())
                serviceProvider.GetInstances<IConfigurationWatchManager>().Register(this);
            _action.Invoke();
        }

        public override async Task Process()
        {
            await Task.Run(_action);
        }

    }
}
