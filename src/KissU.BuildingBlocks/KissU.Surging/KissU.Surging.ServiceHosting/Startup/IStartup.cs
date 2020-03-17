using Autofac;

namespace KissU.Surging.ServiceHosting.Startup
{
    /// <summary>
    /// 启动配置接口
    /// </summary>
    public interface IStartup
    {
        /// <summary>
        /// 配置服务
        /// </summary>
        /// <param name="services">容器构建器</param>
        /// <returns>容器</returns>
        IContainer ConfigureServices(ContainerBuilder services);

        /// <summary>
        /// 配置应用
        /// </summary>
        /// <param name="app">容器</param>
        void Configure(IContainer app);
    }
}