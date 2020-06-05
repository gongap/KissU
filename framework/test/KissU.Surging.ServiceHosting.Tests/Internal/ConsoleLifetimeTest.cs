using System.Threading;
using System.Threading.Tasks;
using KissU.ServiceHosting.Internal;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace KissU.Surging.ServiceHosting.Tests.Internal
{
    /// <summary>
    /// 控制台生命周期测试.
    /// </summary>
    public class ConsoleLifetimeTest
    {
        /// <summary>
        /// 测试构造函数.
        /// </summary>
        [Fact()]
        public void TestConsoleLifetime()
        {
            var logger = Substitute.For<ILogger<ApplicationLifetime>>();
            var applicationLifetime = new ApplicationLifetime(logger);
            var lefttime = new ConsoleLifetime(applicationLifetime);
        }

        /// <summary>
        /// 测试等待启动.
        /// </summary>
        [Fact()]
        public async Task TestWaitForStartAsync()
        {
            var logger = Substitute.For<ILogger<ApplicationLifetime>>();
            var applicationLifetime = new ApplicationLifetime(logger);
            var lefttime = new ConsoleLifetime(applicationLifetime);
            var cancellationToken = new CancellationToken();
            await lefttime.WaitForStartAsync(cancellationToken);
        }

        /// <summary>
        /// 测试停止
        /// </summary>
        [Fact()]
        public async Task TestStopAsync()
        {
            var logger = Substitute.For<ILogger<ApplicationLifetime>>();
            var applicationLifetime = new ApplicationLifetime(logger);
            var lefttime = new ConsoleLifetime(applicationLifetime);
            var cancellationToken = new CancellationToken();
            await lefttime.StopAsync(cancellationToken);
        }

        /// <summary>
        /// 测试释放资源.
        /// </summary>
        [Fact()]
        public void TestDispose()
        {
            var logger = Substitute.For<ILogger<ApplicationLifetime>>();
            var applicationLifetime = new ApplicationLifetime(logger);
            var lefttime = new ConsoleLifetime(applicationLifetime);
            lefttime.Dispose();
        }
    }
}