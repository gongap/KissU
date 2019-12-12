using KissU.Core.CPlatform.Module;
using KissU.Core.CPlatform.Transport.Codec;

namespace KissU.Core.Codec.ProtoBuffer
{
   public class ProtoBufferModule : EnginePartModule
    {
        public override void Initialize(AppModuleContext context)
        {
            base.Initialize(context);
        }

        /// <summary>
        /// Inject dependent third-party components
        /// </summary>
        /// <param name="builder"></param>
        protected override void RegisterBuilder(ContainerBuilderWrapper builder)
        {
            base.RegisterBuilder(builder);
            builder.RegisterType<ProtoBufferTransportMessageCodecFactory>().As<ITransportMessageCodecFactory>().SingleInstance();
        }
    }
}
