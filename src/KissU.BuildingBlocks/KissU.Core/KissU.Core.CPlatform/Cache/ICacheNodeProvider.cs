using System.Collections.Generic;

namespace KissU.Core.CPlatform.Cache
{
   public  interface ICacheNodeProvider
    {
        IEnumerable<ServiceCache> GetServiceCaches();
    }
}
