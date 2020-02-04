using System.Runtime.CompilerServices;
using KissU.Core.Codec.MessagePack.Messages;
using KissU.Core.Codec.MessagePack.Utilities;
using KissU.Core.CPlatform.Messages;
using KissU.Core.CPlatform.Transport.Codec;

namespace KissU.Core.Codec.MessagePack
{
    /// <summary>
    /// MessagePackTransportMessageEncoder. This class cannot be inherited.
    /// Implements the <see cref="KissU.Core.CPlatform.Transport.Codec.ITransportMessageEncoder" />
    /// </summary>
    /// <seealso cref="KissU.Core.CPlatform.Transport.Codec.ITransportMessageEncoder" />
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