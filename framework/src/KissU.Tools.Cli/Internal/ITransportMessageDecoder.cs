using KissU.CPlatform.Messages;

namespace KissU.Tools.Cli.Internal
{
    public  interface ITransportMessageDecoder
    {
        TransportMessage Decode(byte[] data);
    }
}
