﻿using System.Collections.Generic;
using Autofac;
using KissU.CPlatform;
using KissU.CPlatform.Diagnostics;
using KissU.CPlatform.Engines;
using KissU.CPlatform.Routing;
using KissU.CPlatform.Runtime.Server;
using KissU.Modularity;
using KissU.ServiceProxy.Diagnostics;

namespace KissU.ServiceProxy
{
    /// <summary>
    /// ServiceProxyModule.
    /// Implements the <see cref="EnginePartModule" />
    /// </summary>
    /// <seealso cref="EnginePartModule" />
    public class ServiceProxyModule : EnginePartModule
    {
        /// <summary>
        /// Initializes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void Initialize(ModuleInitializationContext context)
        {
            var serviceProvider = context.ServiceProvoider;
            serviceProvider.GetInstances<IServiceProxyFactory>();
            if (AppConfig.ServerOptions.ReloadOnChange)
            {
                new ServiceRouteWatch(serviceProvider
                    ,() =>
                    {
                        //var builder = new ContainerBuilder();
                        //var result = serviceProvider.GetInstances<IServiceEngineBuilder>().ReBuild(builder);
                        //if (result != null)
                        //{
                        //    builder.Update(serviceProvider.Current.ComponentRegistry);
                        //    serviceProvider.GetInstances<IServiceEntryManager>()
                        //        .UpdateEntries(serviceProvider.GetInstances<IEnumerable<IServiceEntryProvider>>());
                        //    //  serviceProvider.GetInstances<IServiceProxyFactory>().RegisterProxType(result.Value.Item2.ToArray(), result.Value.Item1.ToArray());
                        //    serviceProvider.GetInstances<IServiceRouteProvider>().RegisterRoutes(0);
                        //    serviceProvider.GetInstances<IServiceProxyFactory>();
                        //}
                    }
                    );
            }
        }

        /// <summary>
        /// Inject dependent third-party components
        /// </summary>
        /// <param name="builder">构建器包装</param>
        protected override void ConfigureContainer(ContainerBuilderWrapper builder)
        {
            base.ConfigureContainer(builder);
            builder.RegisterType<RpcTransportDiagnosticProcessor>().As<ITracingDiagnosticProcessor>().SingleInstance();
        }
    }
}