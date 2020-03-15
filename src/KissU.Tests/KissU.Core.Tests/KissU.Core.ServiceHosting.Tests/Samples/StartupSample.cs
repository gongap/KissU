using Autofac;
using Microsoft.Extensions.Configuration;

namespace KissU.Core.ServiceHosting.Tests.Samples
{
    /// <summary>
    /// 测试样例
    /// </summary>
    public interface IStartupSample
    {
        void Configure(IContainer container, IConfigurationBuilder builder);

        void ConfigureContainer(IContainer container);

        void ConfigureServices(ContainerBuilder builder);
    }

    /// <summary>
    /// 测试样例
    /// </summary>
    public class StartupSample : IStartupSample
    {
        public void Configure(IContainer container, IConfigurationBuilder builder)
        {
        }

        public void ConfigureContainer(IContainer container)
        {
        }
        public void ConfigureServices(ContainerBuilder builder)
        {
        }
    }
}