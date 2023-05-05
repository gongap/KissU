namespace KissU.DotNetty.DNS.Codecs.Records
{
    public interface IDnsOptPseudoRecord : IDnsRecord
    {
        int ExtendedRcode { get; }
        int Version { get; }
        int Flags { get; }
    }
}
