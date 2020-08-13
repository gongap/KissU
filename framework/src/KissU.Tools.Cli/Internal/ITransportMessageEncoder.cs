using KissU.CPlatform.Messages;

namespace KissU.Tools.Cli.Internal
{
    public interface ITransportMessageEncoder
    {
        byte[] Encode(TransportMessage message);
    }
}
