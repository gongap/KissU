using KissU.Core.CPlatform.Module;
using KissU.Core.CPlatform.Transport.Codec;

namespace KissU.Core.Codec.ProtoBuffer
{
    /// <summary>
    /// ProtoBufferModule.
    /// Implements the <see cref="EnginePartModule" />
    /// </summary>
    /// <seealso cref="EnginePartModule" />
    public class ProtoBufferModule : EnginePartModule
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
            builder.RegisterType<ProtoBufferTransportMessageCodecFactory>().As<ITransportMessageCodecFactory>()
                .SingleInstance();
        }
    }
}