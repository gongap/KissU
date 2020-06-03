using System;
using System.Threading.Tasks;
using Autofac;
using KissU.Core.Hosting;
using KissU.ServiceHosting.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using Xunit;

namespace KissU.Surging.ServiceHosting.Tests.Internal.Implementation
{
    /// <summary>
    /// ServiceHostTest.
    /// </summary>
    public class ServiceHostTest
    {
        /// <summary>
        /// Defines the test method TestRun.
        /// </summary>
        [Fact()]
        public async Task TestRun()
        {
            var containerBuilder = new ContainerBuilder();
            var logger = Substitute.For<ILogger<ApplicationLifetime>>();
            var applicationLifetime = new ApplicationLifetime(logger);
            var serviceProvider = Substitute.For<IServiceProvider>();
            serviceProvider.GetService<IApplicationLifetime>().Returns(applicationLifetime);
            var tag = false;
            applicationLifetime.ApplicationStarted.Register(() =>
            {
                tag = true;
            });
            var consoleLifetime = new ConsoleLifetime(applicationLifetime);
            var serviceHost = new ServiceHost(containerBuilder, serviceProvider, consoleLifetime, null);
            using var host = serviceHost.Run();
            Assert.True(tag);
            await serviceHost.StopAsync();
        }

        /// <summary>
        /// Defines the test method TestInitialize.
        /// </summary>
        [Fact()]
        public void TestInitialize()
        {
            var containerBuilder = new ContainerBuilder();
            var logger = Substitute.For<ILogger<ApplicationLifetime>>();
            var startup = Substitute.For<IStartup>();
            var container = Substitute.For<IContainer>();
            var applicationLifetime = new ApplicationLifetime(logger);
            var consoleLifetime = new ConsoleLifetime(applicationLifetime);
            var services = new ServiceCollection();
            services.AddSingleton(startup);
            var serviceProvider = services.BuildServiceProvider();
            startup.ConfigureContainer(containerBuilder).Returns(container);
            var serviceHost = new ServiceHost(containerBuilder, serviceProvider, consoleLifetime, null);
            serviceHost.Initialize();
        }

        /// <summary>
        /// Defines the test method TestRunAsync.
        /// </summary>
        [Fact()]
        public async Task TestRunAsync()
        {
            var containerBuilder = new ContainerBuilder();
            var logger = Substitute.For<ILogger<ApplicationLifetime>>();
            var applicationLifetime = new ApplicationLifetime(logger);
            var serviceProvider = Substitute.For<IServiceProvider>();
            serviceProvider.GetService<IApplicationLifetime>().Returns(applicationLifetime);
            var tag = false;
            applicationLifetime.ApplicationStarted.Register(() => { tag = true; });
            var consoleLifetime = new ConsoleLifetime(applicationLifetime);
            var serviceHost = new ServiceHost(containerBuilder, serviceProvider, consoleLifetime, null);
            await serviceHost.RunAsync();
            Assert.True(tag);
            await serviceHost.StopAsync();
        }

        /// <summary>
        /// Defines the test method TestStopAsync.
        /// </summary>
        [Fact()]
        public async Task TestStopAsync()
        {
            var containerBuilder = new ContainerBuilder();
            var logger = Substitute.For<ILogger<ApplicationLifetime>>();
            var applicationLifetime = new ApplicationLifetime(logger);
            var serviceProvider = Substitute.For<IServiceProvider>();
            serviceProvider.GetService<IApplicationLifetime>().Returns(applicationLifetime);
            var tag = false;
            applicationLifetime.ApplicationStopped.Register(() => { tag = false; });
            var consoleLifetime = new ConsoleLifetime(applicationLifetime);
            var serviceHost = new ServiceHost(containerBuilder, serviceProvider, consoleLifetime, null);
            using var host = serviceHost.Run();
            await serviceHost.StopAsync();
            Assert.False(tag);
        }
    }
}