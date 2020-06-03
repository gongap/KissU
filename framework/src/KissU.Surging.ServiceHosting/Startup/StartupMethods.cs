using System;
using System.Diagnostics;
using Autofac;

namespace KissU.Surging.ServiceHosting.Startup
{
    /// <summary>
    /// 启动方法
    /// </summary>
    public class StartupMethods
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StartupMethods" /> class.
        /// 初始化
        /// </summary>
        /// <param name="instance">实例</param>
        /// <param name="configure">配置容器的委托</param>
        /// <param name="configureContainer">配置服务的委托</param>
        public StartupMethods(object instance, Action<IContainer> configure, Func<ContainerBuilder, IContainer> configureContainer)
        {
            Debug.Assert(configure != null, "configure != null");
            Debug.Assert(configureContainer != null, "configureContainer != null");

            StartupInstance = instance;
            ConfigureDelegate = configure;
            ConfigureContainerDelegate = configureContainer;
        }

        /// <summary>
        /// 启动实例
        /// </summary>
        public object StartupInstance { get; }

        /// <summary>
        /// 配置服务的委托
        /// </summary>
        public Func<ContainerBuilder, IContainer> ConfigureContainerDelegate { get; }

        /// <summary>
        /// 配置容器的委托
        /// </summary>
        public Action<IContainer> ConfigureDelegate { get; }
    }
}