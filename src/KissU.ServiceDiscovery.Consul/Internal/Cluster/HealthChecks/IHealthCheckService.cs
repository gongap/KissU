using System.Threading.Tasks;
using KissU.Address;

namespace KissU.ServiceDiscovery.Consul.Internal.Cluster.HealthChecks
{
    /// <summary>
    /// Interface IHealthCheckService
    /// </summary>
    public interface IHealthCheckService
    {
        /// <summary>
        /// Monitors the specified address.
        /// </summary>
        /// <param name="address">The address.</param>
        void Monitor(AddressModel address);

        /// <summary>
        /// Determines whether the specified address is health.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns>ValueTask&lt;System.Boolean&gt;.</returns>
        ValueTask<bool> IsHealth(AddressModel address);
    }
}