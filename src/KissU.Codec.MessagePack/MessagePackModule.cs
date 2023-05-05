using KissU.Modularity;
using KissU.CPlatform.Transport.Codec;

namespace KissU.Codec.MessagePack
{
    /// <summary>
    /// MessagePackModule.
    /// Implements the <see cref="EnginePartModule" />
    /// </summary>
    /// <seealso cref="EnginePartModule" />
    public class MessagePackModule : EnginePartModule
    {
        /// <summary>
        /// Inject dependent third-party components
        /// </summary>
        /// <param name="builder">构建器包装</param>
        protected override void ConfigureContainer(ContainerBuilderWrapper builder)
        {
            base.ConfigureContainer(builder);
            builder.RegisterType<MessagePackTransportMessageCodecFactory>().As<ITransportMessageCodecFactory>()
                .SingleInstance();
        }
    }
}