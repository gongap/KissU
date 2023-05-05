using System.Threading;
using System.Threading.Tasks;
using Autofac;
using KissU.Dependency;
using KissU.Modularity;
using KissU.CPlatform.Engines;
using KissU.CPlatform.Runtime.Server;
using KissU.BackgroundServer.Runtime;
using KissU.BackgroundServer.Runtime.Implementation;
using Microsoft.Extensions.Logging;

namespace KissU.BackgroundServer
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
        public override void Initialize(ModuleInitializationContext context)
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
        protected override void ConfigureContainer(ContainerBuilderWrapper builder)
        {
            base.ConfigureContainer(builder);
            builder.Register(provider =>
            {
                return new DefaultBackgroundServiceEntryProvider(
                    provider.Resolve<IServiceEntryManager>(),
                    provider.Resolve<ILogger<DefaultBackgroundServiceEntryProvider>>(),
                    provider.Resolve<CPlatformContainer>()
                );
            }).As(typeof(IBackgroundServiceEntryProvider)).SingleInstance();
        }
    }
}