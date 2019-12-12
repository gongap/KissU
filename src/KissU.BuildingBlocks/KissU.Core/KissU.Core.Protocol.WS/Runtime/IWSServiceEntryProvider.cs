using System.Collections.Generic;

namespace KissU.Core.Protocol.WS.Runtime
{
    public interface IWSServiceEntryProvider
    {
        IEnumerable<WSServiceEntry> GetEntries();
    }
}
