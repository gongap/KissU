using System.Threading.Tasks;
using KissU.Core.CPlatform.Cache;

namespace KissU.Core.Caching.Interfaces
{
    public interface ICacheClient<T>
    {
        T GetClient(CacheEndpoint info, int connectTimeout);

        Task<bool> ConnectionAsync(CacheEndpoint endpoint, int connectTimeout);

    }
}
