using KissU.Modularity;
using KissU.CPlatform;

namespace KissU.Codec.ProtoBuffer
{
    /// <summary>
    /// ContainerBuilderExtensions.
    /// </summary>
    public static class ServiceBuilderExtensions
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