using Autofac;

namespace KissU.ServiceHosting
{
    /// <summary>
    /// 启动配置接口
    /// </summary>
    public interface IStartup
    {
        /// <summary>
        /// 配置服务
        /// </summary>
        /// <param name="builder">容器构建器</param>
        /// <returns>容器</returns>
        IContainer ConfigureContainer(ContainerBuilder builder);

        /// <summary>
        /// 配置容器
        /// </summary>
        /// <param name="container">容器</param>
        void Configure(IContainer container);
    }
}