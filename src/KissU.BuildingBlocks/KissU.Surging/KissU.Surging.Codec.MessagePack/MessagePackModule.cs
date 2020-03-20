﻿using KissU.Core.Module;
using KissU.Surging.CPlatform.Module;
using KissU.Surging.CPlatform.Transport.Codec;

namespace KissU.Surging.Codec.MessagePack
{
    /// <summary>
    /// MessagePackModule.
    /// Implements the <see cref="EnginePartModule" />
    /// </summary>
    /// <seealso cref="EnginePartModule" />
    public class MessagePackModule : EnginePartModule
    {
        /// <summary>
        /// Initializes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void Initialize(AppModuleContext context)
        {
            base.Initialize(context);
        }

        /// <summary>
        /// Inject dependent third-party components
        /// </summary>
        /// <param name="builder">构建器包装</param>
        protected override void RegisterBuilder(ContainerBuilderWrapper builder)
        {
            base.RegisterBuilder(builder);
            builder.RegisterType<MessagePackTransportMessageCodecFactory>().As<ITransportMessageCodecFactory>()
                .SingleInstance();
        }
    }
}