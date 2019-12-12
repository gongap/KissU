using System.Collections.Generic;

namespace KissU.Core.ServiceHosting.Extensions.Runtime
{
   public interface IBackgroundServiceEntryProvider
    {
        IEnumerable<BackgroundServiceEntry> GetEntries(); 
    }
}
