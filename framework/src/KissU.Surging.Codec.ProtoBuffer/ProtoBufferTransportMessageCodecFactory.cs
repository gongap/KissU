using KissU.Surging.CPlatform.Transport.Codec;

namespace KissU.Surging.Codec.ProtoBuffer
{
    /// <summary>
    /// ProtoBufferTransportMessageCodecFactory. This class cannot be inherited.
    /// Implements the <see cref="KissU.Surging.CPlatform.Transport.Codec.ITransportMessageCodecFactory" />
    /// </summary>
    /// <seealso cref="KissU.Surging.CPlatform.Transport.Codec.ITransportMessageCodecFactory" />
    public sealed class ProtoBufferTransportMessageCodecFactory : ITransportMessageCodecFactory
    {
        #region Field

        private readonly ITransportMessageEncoder _transportMessageEncoder = new ProtoBufferTransportMessageEncoder();
        private readonly ITransportMessageDecoder _transportMessageDecoder = new ProtoBufferTransportMessageDecoder();

        #endregion Field

        #region Implementation of ITransportMessageCodecFactory

        /// <summary>
        /// 获取编码器。
        /// </summary>
        /// <returns>编码器实例。</returns>
        public ITransportMessageEncoder GetEncoder()
        {
            return _transportMessageEncoder;
        }

        /// <summary>
        /// Gets the decoder.
        /// </summary>
        /// <returns>ITransportMessageDecoder.</returns>
        public ITransportMessageDecoder GetDecoder()
        {
            return _transportMessageDecoder;
        }

        #endregion Implementation of ITransportMessageCodecFactory
    }
}