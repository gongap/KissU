namespace KissU.Surging.CPlatform.Transport.Codec.Implementation
{
    /// <summary>
    /// Json传输消息编解码器工厂.
    /// Implements the <see cref="ITransportMessageCodecFactory" />
    /// </summary>
    /// <seealso cref="ITransportMessageCodecFactory" />
    public class JsonTransportMessageCodecFactory : ITransportMessageCodecFactory
    {
        private readonly ITransportMessageDecoder _transportMessageDecoder = new JsonTransportMessageDecoder();
        private readonly ITransportMessageEncoder _transportMessageEncoder = new JsonTransportMessageEncoder();

        /// <summary>
        /// 获取编码器。
        /// </summary>
        /// <returns>编码器实例。</returns>
        public ITransportMessageEncoder GetEncoder()
        {
            return _transportMessageEncoder;
        }

        /// <summary>
        /// 获取解码器。
        /// </summary>
        /// <returns>解码器实例。</returns>
        public ITransportMessageDecoder GetDecoder()
        {
            return _transportMessageDecoder;
        }
    }
}