using System.Runtime.CompilerServices;
using KissU.Codec.MessagePack.Messages;
using KissU.Codec.MessagePack.Utilities;
using KissU.CPlatform.Messages;
using KissU.CPlatform.Transport.Codec;

namespace KissU.Codec.MessagePack
{
    /// <summary>
    /// MessagePackTransportMessageDecoder. This class cannot be inherited.
    /// Implements the <see cref="KissU.CPlatform.Transport.Codec.ITransportMessageDecoder" />
    /// </summary>
    /// <seealso cref="KissU.CPlatform.Transport.Codec.ITransportMessageDecoder" />
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