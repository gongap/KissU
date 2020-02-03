using System;
using Autofac;

namespace KissU.Core.ServiceHosting.Startup.Implementation
{
    /// <summary>
    /// 委托启动
    /// </summary>
    public class DelegateStartup : StartupBase<ContainerBuilder>
    {
        /// <summary>
        /// 配置应用
        /// </summary>
        private readonly Action<IContainer> _configureApp;

        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateStartup" /> class.
        /// 初始化
        /// </summary>
        /// <param name="configureApp">配置容器的委托</param>
        public DelegateStartup(Action<IContainer> configureApp)
        {
            _configureApp = configureApp;
        }

        /// <summary>
        /// 配置应用
        /// </summary>
        /// <param name="app">容器</param>
        public override void Configure(IContainer app)
        {
            _configureApp(app);
        }
    }
}