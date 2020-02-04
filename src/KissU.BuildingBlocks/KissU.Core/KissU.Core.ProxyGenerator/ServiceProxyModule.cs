﻿using System.Collections.Generic;
using Autofac;
using KissU.Core.CPlatform;
using KissU.Core.CPlatform.Diagnostics;
using KissU.Core.CPlatform.Engines;
using KissU.Core.CPlatform.Module;
using KissU.Core.CPlatform.Routing;
using KissU.Core.CPlatform.Runtime.Server;
using KissU.Core.ProxyGenerator.Diagnostics;

namespace KissU.Core.ProxyGenerator
{
    /// <summary>
    /// ServiceProxyModule.
    /// Implements the <see cref="EnginePartModule" />
    /// </summary>
    /// <seealso cref="EnginePartModule" />
    public class ServiceProxyModule: EnginePartModule
    {
        /// <summary>
        /// Initializes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void Initialize(AppModuleContext context)
        {
            var serviceProvider = context.ServiceProvoider;
            serviceProvider.GetInstances<IServiceProxyFactory>();
            if (AppConfig.ServerOptions.ReloadOnChange)
            {
                new ServiceRouteWatch(serviceProvider,
                        () =>
                        {
                            var builder = new ContainerBuilder();
                            var result = serviceProvider.GetInstances<IServiceEngineBuilder>().ReBuild(builder);
                            if (result != null)
                            {
                                builder.Update(serviceProvider.Current.ComponentRegistry);
                                serviceProvider.GetInstances<IServiceEntryManager>().UpdateEntries(serviceProvider.GetInstances<IEnumerable<IServiceEntryProvider>>());
                            //  serviceProvider.GetInstances<IServiceProxyFactory>().RegisterProxType(result.Value.Item2.ToArray(), result.Value.Item1.ToArray());
                            serviceProvider.GetInstances<IServiceRouteProvider>().RegisterRoutes(0);
                                serviceProvider.GetInstances<IServiceProxyFactory>();
                            }
                        });
            }
        }

        /// <summary>
        /// Inject dependent third-party components
        /// </summary>
        /// <param name="builder">构建器包装</param>
        protected override void RegisterBuilder(ContainerBuilderWrapper builder)
        {
            base.RegisterBuilder(builder);
            builder.RegisterType<RpcTransportDiagnosticProcessor>().As<ITracingDiagnosticProcessor>().SingleInstance();
        }
    }
}
