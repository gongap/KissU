using System.Collections.Generic;

namespace KissU.Surging.Thrift.Runtime
{
    public interface IThriftServiceEntryProvider
    {
        List<ThriftServiceEntry> GetEntries();
    }
}
