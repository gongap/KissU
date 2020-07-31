using KissU.Modularity;
using KissU.Surging.CPlatform;

namespace KissU.Surging.Codec.MessagePack
{
    /// <summary>
    /// ContainerBuilderExtensions.
    /// </summary>
    public static class ServiceBuilderExtensions
    {
        /// <summary>
        /// 使用messagepack编码解码方式
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns>IServiceBuilder.</returns>
        public static IServiceBuilder UseMessagePackCodec(this IServiceBuilder builder)
        {
            return builder.UseCodec<MessagePackTransportMessageCodecFactory>();
        }
    }
}