using KissU.Core.Codec.ProtoBuffer.Messages;
using KissU.Core.Codec.ProtoBuffer.Utilities;
using KissU.Core.CPlatform.Messages;
using KissU.Core.CPlatform.Transport.Codec;

namespace KissU.Core.Codec.ProtoBuffer
{
    /// <summary>
    /// ProtoBufferTransportMessageEncoder. This class cannot be inherited.
    /// Implements the <see cref="KissU.Core.CPlatform.Transport.Codec.ITransportMessageEncoder" />
    /// </summary>
    /// <seealso cref="KissU.Core.CPlatform.Transport.Codec.ITransportMessageEncoder" />
    public sealed class ProtoBufferTransportMessageEncoder : ITransportMessageEncoder
    {
        #region Implementation of ITransportMessageEncoder

        /// <summary>
        /// Encodes the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>System.Byte[].</returns>
        public byte[] Encode(TransportMessage message)
        {
            var transportMessage = new ProtoBufferTransportMessage(message)
            {
                Id = message.Id,
                ContentType = message.ContentType
            };

            return SerializerUtilitys.Serialize(transportMessage);
        }

        #endregion Implementation of ITransportMessageEncoder
    }
}