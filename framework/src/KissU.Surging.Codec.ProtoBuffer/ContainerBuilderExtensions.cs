
using KissU.Module;
using KissU.Surging.CPlatform;

namespace KissU.Surging.Codec.ProtoBuffer
{
    /// <summary>
    /// ContainerBuilderExtensions.
    /// </summary>
    public static class ContainerBuilderExtensions
    {
        /// <summary>
        /// Uses the proto buffer codec.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns>IServiceBuilder.</returns>
        public static IServiceBuilder UseProtoBufferCodec(this IServiceBuilder builder)
        {
            return builder.UseCodec<ProtoBufferTransportMessageCodecFactory>();
        }
    }
}