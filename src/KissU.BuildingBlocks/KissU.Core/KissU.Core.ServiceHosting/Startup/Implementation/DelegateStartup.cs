using System;
using Autofac;

namespace KissU.Core.ServiceHosting.Startup.Implementation
{
    public  class DelegateStartup : StartupBase<ContainerBuilder>
    {
        private Action<IContainer> _configureApp;

        public DelegateStartup(Action<IContainer> configureApp) : base()
        {
            _configureApp = configureApp;
        }

        public override void Configure(IContainer app) => _configureApp(app);
    }
}
