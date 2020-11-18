using KissU.Address;

namespace KissU.ApiGateWay.ServiceDiscovery.Implementation
{
    /// <summary>
    /// ServiceAddressModel.
    /// </summary>
    public class ServiceAddressModel
    {
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        public AddressModel Address { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is health.
        /// </summary>
        public bool IsHealth { get; set; }
    }
}