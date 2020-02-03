﻿using System;
using KissU.Core.Configuration.Apollo.Configurations;
using KissU.Core.CPlatform.Module;

namespace KissU.Core.Configuration.Apollo
{
    /// <summary>
    /// ApolloModule.
    /// Implements the <see cref="KissU.Core.CPlatform.Module.EnginePartModule" />
    /// </summary>
    /// <seealso cref="KissU.Core.CPlatform.Module.EnginePartModule" />
    public class ApolloModule : EnginePartModule
    {
        /// <summary>
        /// Initializes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void Initialize(AppModuleContext context)
        {
            var serviceProvider = context.ServiceProvoider;
            base.Initialize(context);
            serviceProvider.GetInstances<IConfigurationFactory>().Create();
        }

        /// <summary>
        /// Inject dependent third-party components
        /// </summary>
        /// <param name="builder">构建器包装</param>
        protected override void RegisterBuilder(ContainerBuilderWrapper builder)
        {
            base.RegisterBuilder(builder);
            builder.RegisterType(typeof(ConfigurationFactory)).As(typeof(IConfigurationFactory));
        }
    }
}
