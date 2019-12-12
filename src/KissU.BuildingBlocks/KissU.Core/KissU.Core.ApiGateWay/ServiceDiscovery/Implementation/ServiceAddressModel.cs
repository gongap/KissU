using KissU.Core.CPlatform.Address;

namespace KissU.Core.ApiGateWay.ServiceDiscovery.Implementation
{
    public class ServiceAddressModel 
    {
        public AddressModel Address { get; set; }

        public  bool IsHealth { get; set; }
    }
}
