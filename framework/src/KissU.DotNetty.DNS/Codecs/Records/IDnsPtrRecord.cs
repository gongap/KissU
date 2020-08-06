
namespace KissU.DotNetty.DNS.Codecs.Records
{
    public interface IDnsPtrRecord : IDnsRecord
    {
        string HostName { get; }
    }
}
