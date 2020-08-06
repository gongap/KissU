using DotNetty.Buffers;
using KissU.DotNetty.DNS.Codecs.Records;

namespace KissU.DotNetty.DNS.Codecs
{
    public interface IDnsRecordDecoder
    {
        IDnsQuestion DecodeQuestion(IByteBuffer inputBuffer);
        IDnsRecord DecodeRecord(IByteBuffer inputBuffer);
    }
}
