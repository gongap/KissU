using Autofac;

namespace KissU.ServiceHosting.Startup
{
    /// <summary>
    /// 启动基类
    /// </summary>
    public abstract class StartupBase : IStartup
    {
        /// <summary>
        /// 配置容器
        /// </summary>
        /// <param name="container">容器</param>
        public abstract void Configure(IContainer container);

        /// <summary>
        /// 配置服务
        /// </summary>
        /// <param name="builder">容器构建器</param>
        /// <returns>容器</returns>
        IContainer IStartup.ConfigureContainer(ContainerBuilder builder)
        {
            ConfigureContainer(builder);
            return BuildServiceProvider(builder);
        }

        /// <summary>
        /// 配置服务
        /// </summary>
        /// <param name="builder">容器构建器</param>
        public virtual void ConfigureContainer(ContainerBuilder builder)
        {
        }

        /// <summary>
        /// 构建服务提供程序
        /// </summary>
        /// <param name="builder">容器构建器</param>
        /// <returns>容器</returns>
        public virtual IContainer BuildServiceProvider(ContainerBuilder builder)
        {
            return builder.Build();
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
        /// <param name="builder">容器构建器</param>
        /// <returns>容器</returns>
        public override IContainer BuildServiceProvider(ContainerBuilder builder)
        {
            return builder.Build();
        }

        /// <summary>
        /// 配置服务
        /// </summary>
        /// <param name="builder">构建器类型</param>
        public virtual void ConfigureContainer(TBuilder builder)
        {
        }
    }
}