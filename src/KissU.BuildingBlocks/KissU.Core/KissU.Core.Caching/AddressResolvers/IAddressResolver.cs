using System.Threading.Tasks;
using KissU.Core.Caching.HashAlgorithms;

namespace KissU.Core.Caching.AddressResolvers
{
    public interface IAddressResolver
    {
        ValueTask<ConsistentHashNode> Resolver(string cacheId, string item);
    }
}
