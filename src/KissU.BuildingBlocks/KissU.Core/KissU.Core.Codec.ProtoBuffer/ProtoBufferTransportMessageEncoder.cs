using KissU.Core.Codec.ProtoBuffer.Messages;
using KissU.Core.Codec.ProtoBuffer.Utilities;
using KissU.Core.CPlatform.Messages;
using KissU.Core.CPlatform.Transport.Codec;

namespace KissU.Core.Codec.ProtoBuffer
{
    public sealed class ProtoBufferTransportMessageEncoder : ITransportMessageEncoder
    {
        #region Implementation of ITransportMessageEncoder

        public byte[] Encode(TransportMessage message)
        {
            var transportMessage = new ProtoBufferTransportMessage(message)
            {
                Id = message.Id,
                ContentType = message.ContentType,
            };

            return SerializerUtilitys.Serialize(transportMessage);
        }

        #endregion Implementation of ITransportMessageEncoder
    }
}