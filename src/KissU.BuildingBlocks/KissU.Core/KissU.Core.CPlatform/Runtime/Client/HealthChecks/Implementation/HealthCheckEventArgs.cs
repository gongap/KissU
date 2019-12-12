using KissU.Core.CPlatform.Address;

namespace KissU.Core.CPlatform.Runtime.Client.HealthChecks.Implementation
{
   public class HealthCheckEventArgs
    {
        public HealthCheckEventArgs(AddressModel address)
        {
            Address = address;
        }

        public HealthCheckEventArgs(AddressModel address,bool health)
        {
            Address = address;
            Health = health;
        }

        public AddressModel Address { get; private set; }

        public bool Health { get; private set; }
    }
}
