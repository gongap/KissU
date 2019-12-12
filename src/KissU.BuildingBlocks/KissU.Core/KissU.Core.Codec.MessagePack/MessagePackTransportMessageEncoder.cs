using System.Runtime.CompilerServices;
using KissU.Core.Codec.MessagePack.Messages;
using KissU.Core.Codec.MessagePack.Utilities;
using KissU.Core.CPlatform.Messages;
using KissU.Core.CPlatform.Transport.Codec;

namespace KissU.Core.Codec.MessagePack
{
   public sealed class MessagePackTransportMessageEncoder:ITransportMessageEncoder
    {
        #region Implementation of ITransportMessageEncoder

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte[] Encode(TransportMessage message)
        {
            var transportMessage = new MessagePackTransportMessage(message)
            {
                Id = message.Id,
                ContentType = message.ContentType,
            };
            return SerializerUtilitys.Serialize(transportMessage);
        }
        #endregion Implementation of ITransportMessageEncoder
    }
}
