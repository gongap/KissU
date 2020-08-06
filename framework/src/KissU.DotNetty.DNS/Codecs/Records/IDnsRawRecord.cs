using DotNetty.Buffers;

namespace KissU.DotNetty.DNS.Codecs.Records
{
    public interface IDnsRawRecord : IDnsRecord, IByteBufferHolder
    {
    }
}
