using System.Threading;
using System.Threading.Tasks;
using Autofac;
using KissU.Core;
using KissU.Core.Module;
using KissU.Surging.CPlatform;
using KissU.Surging.CPlatform.Engines;
using KissU.Surging.CPlatform.Module;
using KissU.Surging.CPlatform.Runtime.Server;
using KissU.Surging.BackgroundServer.Runtime;
using KissU.Surging.BackgroundServer.Runtime.Implementation;
using Microsoft.Extensions.Logging;

namespace KissU.Surging.BackgroundServer
{
    /// <summary>
    /// 服务主机模块
    /// </summary>
    public class BackgroundModule : EnginePartModule
    {
        /// <summary>
        /// Initializes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void Initialize(AppModuleContext context)
        {
            var serviceProvider = context.ServiceProvoider;
            base.Initialize(context);
            serviceProvider.GetInstances<IServiceEngineLifetime>().ServiceEngineStarted.Register(() =>
            {
                var provider = serviceProvider.GetInstances<IBackgroundServiceEntryProvider>();
                var entries = provider.GetEntries();
                foreach (var entry in entries)
                {
                    var cts = new CancellationTokenSource();
                    Task.Run(() =>
                    {
                        try
                        {
                            entry.Behavior.StartAsync(cts.Token);
                        }
                        catch
                        {
                            entry.Behavior.StopAsync(cts.Token);
                        }
                    });
                }
            });
        }

        /// <summary>
        /// 注册服务
        /// </summary>
        /// <param name="builder">构建器包装</param>
        protected override void RegisterBuilder(ContainerBuilderWrapper builder)
        {
            base.RegisterBuilder(builder);
            builder.Register(provider =>
            {
                return new DefaultBackgroundServiceEntryProvider(
                    provider.Resolve<IServiceEntryProvider>(),
                    provider.Resolve<ILogger<DefaultBackgroundServiceEntryProvider>>(),
                    provider.Resolve<CPlatformContainer>()
                );
            }).As(typeof(IBackgroundServiceEntryProvider)).SingleInstance();
        }
    }
}