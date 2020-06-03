using System;
using Autofac;

namespace KissU.ServiceHosting.Startup
{
    /// <summary>
    /// 委托启动类
    /// </summary>
    public class DelegateStartup : StartupBase<ContainerBuilder>
    {
        /// <summary>
        /// 配置容器
        /// </summary>
        private readonly Action<IContainer> _configure;

        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateStartup" /> class.
        /// 初始化
        /// </summary>
        /// <param name="configure">配置容器的委托</param>
        public DelegateStartup(Action<IContainer> configure)
        {
            _configure = configure;
        }

        /// <summary>
        /// 配置容器
        /// </summary>
        /// <param name="container">容器</param>
        public override void Configure(IContainer container)
        {
            _configure(container);
        }
    }
}