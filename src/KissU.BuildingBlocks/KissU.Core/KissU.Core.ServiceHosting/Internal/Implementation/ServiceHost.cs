using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using KissU.Core.ServiceHosting.Startup;
using Microsoft.Extensions.DependencyInjection;

namespace KissU.Core.ServiceHosting.Internal.Implementation
{
    /// <summary>
    /// 服务主机
    /// </summary>
    public class ServiceHost : IServiceHost
    {
        private readonly ContainerBuilder _builder;
        private readonly IServiceProvider _hostingServiceProvider;
        private readonly IHostLifetime _hostLifetime;
        private readonly List<Action<IContainer>> _mapServicesDelegates;
        private IApplicationLifetime _applicationLifetime;
        private IContainer _applicationServices;
        private IStartup _startup;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="builder">容器构建器</param>
        /// <param name="hostingServiceProvider">服务提供程序</param>
        /// <param name="hostLifetime">主机生命周期</param>
        /// <param name="mapServicesDelegate">容器服务映射委托</param>
        public ServiceHost(ContainerBuilder builder,
            IServiceProvider hostingServiceProvider,
            IHostLifetime hostLifetime,
            List<Action<IContainer>> mapServicesDelegate)
        {
            _builder = builder;
            _hostingServiceProvider = hostingServiceProvider;
            _hostLifetime = hostLifetime;
            _mapServicesDelegates = mapServicesDelegate;
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            (_hostingServiceProvider as IDisposable)?.Dispose();
        }

        /// <summary>
        /// 启动
        /// </summary>
        /// <returns></returns>
        public IDisposable Run()
        {
            RunAsync().GetAwaiter().GetResult();
            return this;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns>容器</returns>
        public IContainer Initialize()
        {
            if (_applicationServices == null)
            {
                _applicationServices = BuildApplication();
            }

            return _applicationServices;
        }

        /// <summary>
        /// 运行
        /// </summary>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns><placeholder>A <see cref="Task"/> representing the asynchronous operation.</placeholder></returns>
        public async Task RunAsync(CancellationToken cancellationToken = default)
        {
            if (_applicationServices != null)
            {
                MapperServices(_applicationServices);
            }

            if (_hostLifetime != null)
            {
                _applicationLifetime = _hostingServiceProvider.GetService<IApplicationLifetime>();
                await _hostLifetime.WaitForStartAsync(cancellationToken);
                cancellationToken.ThrowIfCancellationRequested();
                _applicationLifetime?.NotifyStarted();
            }
        }

        /// <summary>
        /// 停止
        /// </summary>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns><placeholder>A <see cref="Task"/> representing the asynchronous operation.</placeholder></returns>
        public async Task StopAsync(CancellationToken cancellationToken = default)
        {
            using (var cts = new CancellationTokenSource(2000))
            using (var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(cts.Token, cancellationToken))
            {
                var token = linkedCts.Token;
                _applicationLifetime?.StopApplication();
                token.ThrowIfCancellationRequested();
                await _hostLifetime.StopAsync(token);
                _applicationLifetime?.NotifyStopped();
            }
        }

        private void EnsureApplicationServices()
        {
            if (_applicationServices == null)
            {
                EnsureStartup();
                _applicationServices = _startup.ConfigureServices(_builder);
            }
        }

        private void EnsureStartup()
        {
            if (_startup != null)
            {
                return;
            }

            _startup = _hostingServiceProvider.GetRequiredService<IStartup>();
        }

        private IContainer BuildApplication()
        {
            try
            {
                EnsureApplicationServices();
                Action<IContainer> configure = _startup.Configure;
                if (_applicationServices == null)
                {
                    _applicationServices = _builder.Build();
                }

                configure(_applicationServices);
                return _applicationServices;
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("应用程序启动异常: " + ex);
                throw;
            }
        }

        private void MapperServices(IContainer mapper)
        {
            foreach (var mapServices in _mapServicesDelegates)
            {
                mapServices(mapper);
            }
        }
    }
}
