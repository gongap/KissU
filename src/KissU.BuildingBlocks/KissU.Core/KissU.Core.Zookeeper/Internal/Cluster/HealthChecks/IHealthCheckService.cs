using System.Threading.Tasks;
using KissU.Core.CPlatform.Address;

namespace KissU.Core.Zookeeper.Internal.Cluster.HealthChecks
{
   public interface IHealthCheckService
    {
        void Monitor(AddressModel address);

        ValueTask<bool> IsHealth(AddressModel address);
    }
}
