using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using Microsoft.Extensions.DependencyInjection;

namespace KissU.ServiceHosting.Internal
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
        /// Initializes a new instance of the <see cref="ServiceHost" /> class.
        /// 初始化
        /// </summary>
        /// <param name="builder">容器构建器</param>
        /// <param name="hostingServiceProvider">服务提供程序</param>
        /// <param name="hostLifetime">主机生命周期</param>
        /// <param name="mapServicesDelegate">容器服务映射委托</param>
        public ServiceHost(ContainerBuilder builder, IServiceProvider hostingServiceProvider, IHostLifetime hostLifetime, List<Action<IContainer>> mapServicesDelegate)
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
        /// <returns>IDisposable.</returns>
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
        /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
        public async Task RunAsync(CancellationToken cancellationToken = default)
        {
            if (_applicationServices != null)
            {
                MapperServices(_applicationServices);
            }

            if (_hostLifetime != null)
            {
                _applicationLifetime = _hostingServiceProvider.GetService<IApplicationLifetime>();
                await _hostLifetime.WaitForStartAsync(cancellationToken).ConfigureAwait(true);
                cancellationToken.ThrowIfCancellationRequested();
                _applicationLifetime?.NotifyStarted();
            }
        }

        /// <summary>
        /// 停止
        /// </summary>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
        public async Task StopAsync(CancellationToken cancellationToken = default)
        {
            using var cts = new CancellationTokenSource(2000);
            using var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(cts.Token, cancellationToken);
            var token = linkedCts.Token;
            _applicationLifetime?.StopApplication();
            token.ThrowIfCancellationRequested();
            await _hostLifetime.StopAsync(token).ConfigureAwait(true);
            _applicationLifetime?.NotifyStopped();
        }

        /// <summary>
        /// 确保应用程序服务.
        /// </summary>
        private void EnsureApplicationServices()
        {
            if (_applicationServices == null)
            {
                EnsureStartup();
                _applicationServices = _startup.ConfigureContainer(_builder);
            }
        }

        /// <summary>
        /// 确保启动.
        /// </summary>
        private void EnsureStartup()
        {
            if (_startup != null)
            {
                return;
            }

            _startup = _hostingServiceProvider.GetRequiredService<IStartup>();
        }

        /// <summary>
        /// 构建应用程序.
        /// </summary>
        /// <returns>容器.</returns>
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

        /// <summary>
        /// 映射服务.
        /// </summary>
        /// <param name="mapper">映射器</param>
        private void MapperServices(IContainer mapper)
        {
            foreach (var mapServices in _mapServicesDelegates)
            {
                mapServices(mapper);
            }
        }
    }
}