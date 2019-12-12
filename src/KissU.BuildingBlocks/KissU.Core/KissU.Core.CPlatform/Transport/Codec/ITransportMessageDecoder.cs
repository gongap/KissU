using KissU.Core.CPlatform.Messages;

namespace KissU.Core.CPlatform.Transport.Codec
{
    public interface ITransportMessageDecoder
    {
        TransportMessage Decode(byte[] data);
    }
}