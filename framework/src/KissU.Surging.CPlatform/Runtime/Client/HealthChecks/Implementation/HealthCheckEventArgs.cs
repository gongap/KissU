using KissU.Core.Address;

namespace KissU.Surging.CPlatform.Runtime.Client.HealthChecks.Implementation
{
    /// <summary>
    /// 健康检查事件仓储.
    /// </summary>
    public class HealthCheckEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HealthCheckEventArgs" /> class.
        /// </summary>
        /// <param name="address">The address.</param>
        public HealthCheckEventArgs(AddressModel address)
        {
            Address = address;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HealthCheckEventArgs" /> class.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <param name="health">if set to <c>true</c> [health].</param>
        public HealthCheckEventArgs(AddressModel address, bool health)
        {
            Address = address;
            Health = health;
        }

        /// <summary>
        /// 地址.
        /// </summary>
        public AddressModel Address { get; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="HealthCheckEventArgs" /> is health.
        /// </summary>
        public bool Health { get; }
    }
}