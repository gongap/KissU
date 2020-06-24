using KissU.Modularity;
using KissU.Surging.CPlatform.Transport.Codec;

namespace KissU.Surging.Codec.ProtoBuffer
{
    /// <summary>
    /// ProtoBufferModule.
    /// Implements the <see cref="EnginePartModule" />
    /// </summary>
    /// <seealso cref="EnginePartModule" />
    public class ProtoBufferModule : EnginePartModule
    {
        /// <summary>
        /// Inject dependent third-party components
        /// </summary>
        /// <param name="builder">构建器包装</param>
        protected override void ConfigureContainer(ContainerBuilderWrapper builder)
        {
            base.ConfigureContainer(builder);
            builder.RegisterType<ProtoBufferTransportMessageCodecFactory>().As<ITransportMessageCodecFactory>()
                .SingleInstance();
        }
    }
}