using KissU.Surging.ServiceHosting.Internal;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace KissU.Surging.ServiceHosting.Tests.Internal.Implementation
{
    /// <summary>
    /// ApplicationLifetimeTest.
    /// </summary>
    public class ApplicationLifetimeTest
    {
        /// <summary>
        /// Defines the test method TestApplicationLifetime.
        /// </summary>
        [Fact()]
        public void TestApplicationLifetime()
        {
            var logger = Substitute.For<ILogger<ApplicationLifetime>>(); 
            var lefttime = new ApplicationLifetime(logger);
            Assert.True(lefttime.ApplicationStarted != null);
            Assert.True(lefttime.ApplicationStopped != null);
            Assert.True(lefttime.ApplicationStopping != null);
        }

        /// <summary>
        /// Defines the test method TestNotifyStarted.
        /// </summary>
        [Fact()]
        public void TestNotifyStarted()
        {
            var logger = Substitute.For<ILogger<ApplicationLifetime>>();
            var lefttime = new ApplicationLifetime(logger);
            lefttime.NotifyStarted();
            Assert.True(lefttime.ApplicationStarted.IsCancellationRequested);
        }

        /// <summary>
        /// Defines the test method TestNotifyStopped.
        /// </summary>
        [Fact()]
        public void TestNotifyStopped()
        {
            var logger = Substitute.For<ILogger<ApplicationLifetime>>();
            var lefttime = new ApplicationLifetime(logger);
            lefttime.NotifyStopped();
            Assert.True(lefttime.ApplicationStopped.IsCancellationRequested);
        }

        /// <summary>
        /// Defines the test method TestStopApplication.
        /// </summary>
        [Fact()]
        public void TestStopApplication()
        {
            var logger = Substitute.For<ILogger<ApplicationLifetime>>();
            var lefttime = new ApplicationLifetime(logger);
            lefttime.StopApplication();
            Assert.True(lefttime.ApplicationStopped.IsCancellationRequested);
        }
    }
}