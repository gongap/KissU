using System.Collections.Generic;

namespace KissU.Core.DotNettyWSServer.Runtime
{
   public interface IWSServiceEntryProvider
    {
        IEnumerable<WSServiceEntry> GetEntries();
    }
}
