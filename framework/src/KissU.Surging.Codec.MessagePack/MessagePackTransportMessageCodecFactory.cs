using System.Runtime.CompilerServices;
using KissU.Surging.CPlatform.Transport.Codec;

namespace KissU.Surging.Codec.MessagePack
{
    /// <summary>
    /// MessagePackTransportMessageCodecFactory. This class cannot be inherited.
    /// Implements the <see cref="KissU.Surging.CPlatform.Transport.Codec.ITransportMessageCodecFactory" />
    /// </summary>
    /// <seealso cref="KissU.Surging.CPlatform.Transport.Codec.ITransportMessageCodecFactory" />
    public sealed class MessagePackTransportMessageCodecFactory : ITransportMessageCodecFactory
    {
        #region Field

        private readonly ITransportMessageEncoder _transportMessageEncoder = new MessagePackTransportMessageEncoder();
        private readonly ITransportMessageDecoder _transportMessageDecoder = new MessagePackTransportMessageDecoder();

        #endregion Field

        #region Implementation of ITransportMessageCodecFactory

        /// <inheritdoc />
        /// <summary>
        /// 获取编码器
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ITransportMessageEncoder GetEncoder()
        {
            return _transportMessageEncoder;
        }

        /// <inheritdoc />
        /// <summary>
        /// 获取解码器
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ITransportMessageDecoder GetDecoder()
        {
            return _transportMessageDecoder;
        }

        #endregion Implementation of ITransportMessageCodecFactory
    }
}