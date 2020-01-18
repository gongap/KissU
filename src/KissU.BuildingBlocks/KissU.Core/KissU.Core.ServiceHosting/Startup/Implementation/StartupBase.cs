using Autofac;

namespace KissU.Core.ServiceHosting.Startup.Implementation
{
    /// <summary>
    /// 启动基类
    /// </summary>
    public abstract class StartupBase : IStartup
    {
        /// <summary>
        /// 配置容器
        /// </summary>
        /// <param name="app">容器</param>
        public abstract void Configure(IContainer app);

        /// <summary>
        /// 配置服务
        /// </summary>
        /// <param name="services">容器构建器</param>
        /// <returns>容器</returns>
        IContainer IStartup.ConfigureServices(ContainerBuilder services)
        {
            ConfigureServices(services);
            return CreateServiceProvider(services);
        }

        /// <summary>
        /// 配置服务
        /// </summary>
        /// <param name="services">容器构建器</param>
        public virtual void ConfigureServices(ContainerBuilder services)
        {
        }

        /// <summary>
        /// 创建服务提供程序
        /// </summary>
        /// <param name="services">容器构建器</param>
        /// <returns>容器</returns>
        public virtual IContainer CreateServiceProvider(ContainerBuilder services)
        {
            return services.Build();
        }
    }

    /// <summary>
    /// 启动基类
    /// </summary>
    /// <typeparam name="TBuilder">构建器类型</typeparam>
    public abstract class StartupBase<TBuilder> : StartupBase
    {
        /// <summary>
        /// 创建服务提供程序
        /// </summary>
        /// <param name="services">容器构建器</param>
        /// <returns>容器</returns>
        public override IContainer CreateServiceProvider(ContainerBuilder services)
        {
            return services.Build();
        }

        /// <summary>
        /// 配置容器
        /// </summary>
        /// <param name="builder">构建器类型</param>
        public virtual void ConfigureContainer(TBuilder builder)
        {
        }
    }
}
