using System.Collections.Generic;
using System.Threading.Tasks;
using Consul;

namespace KissU.Core.Consul.Internal
{
    public  interface IConsulClientProvider
    {
        ValueTask<ConsulClient> GetClient();

        ValueTask<IEnumerable<ConsulClient>> GetClients();

        ValueTask Check();
    }
}
