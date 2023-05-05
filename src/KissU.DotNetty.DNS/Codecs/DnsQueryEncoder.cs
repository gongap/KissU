using System;
using DotNetty.Buffers;
using KissU.DotNetty.DNS.Codecs.Messages;
using KissU.DotNetty.DNS.Codecs.Records;

namespace KissU.DotNetty.DNS.Codecs
{
    sealed class DnsQueryEncoder
    {
        private readonly IDnsRecordEncoder recordEncoder;

        public DnsQueryEncoder() : this(new DefaultDnsRecordEncoder()) { }

        public DnsQueryEncoder(IDnsRecordEncoder recordEncoder)
        {
            this.recordEncoder = recordEncoder ?? throw new ArgumentNullException(nameof(recordEncoder));
        }

        public void Encode(IDnsQuery query, IByteBuffer buffer)
        {
            EncodeHeader(query, buffer);
            EncodeQuestions(query, buffer);
            EncodeRecords(query, DnsSection.ADDITIONAL, buffer);
        }

        private void EncodeHeader(IDnsQuery query, IByteBuffer buffer)
        {
            buffer.WriteShort(query.Id);
            int flags = 0;
            flags |= (query.OpCode.ByteValue & 0xFF) << 14;
            if (query.IsRecursionDesired)
                flags |= 1 << 8;

            buffer.WriteShort(flags);
            buffer.WriteShort(query.Count(DnsSection.QUESTION));
            buffer.WriteShort(0);
            buffer.WriteShort(0);
            buffer.WriteShort(query.Count(DnsSection.ADDITIONAL));
        }

        private void EncodeQuestions(IDnsQuery query, IByteBuffer buffer)
        {
            int count = query.Count(DnsSection.QUESTION);
            for (int i = 0; i < count; i++)
            {
                recordEncoder.EncodeQuestion(query.GetRecord<IDnsQuestion>(DnsSection.QUESTION, i), buffer);
            }
        }

        private void EncodeRecords(IDnsQuery query, DnsSection section, IByteBuffer buffer)
        {
            int count = query.Count(section);
            for (int i = 0; i < count; i++)
            {
                recordEncoder.EncodeRecord(query.GetRecord<IDnsRecord>(section, i), buffer);
            }
        }
    }
}
