using System.Collections.Generic;

namespace KissU.Thrift.Runtime
{
    public interface IThriftServiceEntryProvider
    {
        List<ThriftServiceEntry> GetEntries();
    }
}
