using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Core.CPlatform.Address;

namespace KissU.Core.Protocol.Mqtt.Internal.Runtime
{
   public interface IMqttBrokerEntryManger
    {
        ValueTask<IEnumerable<AddressModel>> GetMqttBrokerAddress(string topic);

        Task CancellationReg(string topic,AddressModel addressModel);

        Task Register(string topic, AddressModel addressModel);
    }
}
