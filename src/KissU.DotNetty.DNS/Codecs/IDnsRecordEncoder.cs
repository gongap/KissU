using DotNetty.Buffers;
using KissU.DotNetty.DNS.Codecs.Records;

namespace KissU.DotNetty.DNS.Codecs
{
    public interface IDnsRecordEncoder
    {
        void EncodeQuestion(IDnsQuestion question, IByteBuffer output);
        void EncodeRecord(IDnsRecord record, IByteBuffer output);
    }
}
