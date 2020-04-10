using System.Runtime.CompilerServices;
using KissU.Surging.Codec.MessagePack.Messages;
using KissU.Surging.Codec.MessagePack.Utilities;
using KissU.Surging.CPlatform.Messages;
using KissU.Surging.CPlatform.Transport.Codec;

namespace KissU.Surging.Codec.MessagePack
{
    /// <summary>
    /// MessagePackTransportMessageDecoder. This class cannot be inherited.
    /// Implements the <see cref="KissU.Surging.CPlatform.Transport.Codec.ITransportMessageDecoder" />
    /// </summary>
    /// <seealso cref="KissU.Surging.CPlatform.Transport.Codec.ITransportMessageDecoder" />
    public sealed class MessagePackTransportMessageDecoder : ITransportMessageDecoder
    {
        #region Implementation of ITransportMessageDecoder

        /// <summary>
        /// Decodes the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>TransportMessage.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TransportMessage Decode(byte[] data)
        {
            var message = SerializerUtilitys.Deserialize<MessagePackTransportMessage>(data);
            return message.GetTransportMessage();
        }

        #endregion Implementation of ITransportMessageDecoder
    }
}