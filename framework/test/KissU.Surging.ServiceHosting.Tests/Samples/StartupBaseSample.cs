using Autofac;
using KissU.ServiceHosting.Startup;

namespace KissU.Surging.ServiceHosting.Tests.Samples
{
    /// <summary>
    /// 启动基类样例.
    /// Implements the <see cref="StartupBase{ContainerBuilder}" />
    /// </summary>
    /// <seealso cref="StartupBase{ContainerBuilder}" />
    public class StartupBaseSample : StartupBase<ContainerBuilder>
    {
        /// <summary>
        /// 配置容器
        /// </summary>
        /// <param name="container">容器</param>
        public override void Configure(IContainer container)
        {
        }
    }
}