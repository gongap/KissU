using System.Collections.Generic;

namespace KissU.Core.CPlatform.Cache
{
   /// <summary>
   /// 缓存节点提供程序
   /// </summary>
   public  interface ICacheNodeProvider
    {
        IEnumerable<ServiceCache> GetServiceCaches();
    }
}
