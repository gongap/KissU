using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KissU.Service.Host
{
    /// <summary>
    /// 启动配置
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// 初始化启动配置
        /// </summary>
        public Startup(IConfigurationBuilder build)
        {
        }

        /// <summary>
        /// 配置服务
        /// </summary>
        public IContainer ConfigureContainer(ContainerBuilder builder)
        {
            var services = new ServiceCollection();
            services.AddLogging();
            builder.Populate(services);
            return builder.Build();
        }

        /// <summary>
        /// 配置容器
        /// </summary>
        public void Configure(IContainer container)
        {
        }
    }
}