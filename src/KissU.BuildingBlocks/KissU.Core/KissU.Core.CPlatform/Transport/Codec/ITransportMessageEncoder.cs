using KissU.Core.CPlatform.Messages;

namespace KissU.Core.CPlatform.Transport.Codec
{
    public interface ITransportMessageEncoder
    {
        byte[] Encode(TransportMessage message);
    }
}