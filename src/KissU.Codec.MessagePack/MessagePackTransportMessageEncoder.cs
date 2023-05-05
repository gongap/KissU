using System.Runtime.CompilerServices;
using KissU.Codec.MessagePack.Messages;
using KissU.Codec.MessagePack.Utilities;
using KissU.CPlatform.Messages;
using KissU.CPlatform.Transport.Codec;

namespace KissU.Codec.MessagePack
{
    /// <summary>
    /// MessagePackTransportMessageEncoder. This class cannot be inherited.
    /// Implements the <see cref="KissU.CPlatform.Transport.Codec.ITransportMessageEncoder" />
    /// </summary>
    /// <seealso cref="KissU.CPlatform.Transport.Codec.ITransportMessageEncoder" />
    public sealed class MessagePackTransportMessageEncoder : ITransportMessageEncoder
    {
        #region Implementation of ITransportMessageEncoder

        /// <summary>
        /// Encodes the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>System.Byte[].</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte[] Encode(TransportMessage message)
        {
            var transportMessage = new MessagePackTransportMessage(message)
            {
                Id = message.Id,
                ContentType = message.ContentType
            };
            return SerializerUtilitys.Serialize(transportMessage);
        }

        #endregion Implementation of ITransportMessageEncoder
    }
}