using System.Threading.Tasks;
using KissU.CPlatform.Runtime.Client.Address.Resolvers.Implementation.Selectors.Implementation;
using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.CPlatform.Support.Attributes;
using KissU.Dependency;
using KissU.Msm.Sample.Service.Contracts.Models;

namespace KissU.Msm.Sample.Service.Contracts
{
    [ServiceBundle("Device/{Service}/{Async}")] 
    public interface IDeviceService : IServiceKey
    { 
        [Command(ShuntStrategy = AddressSelectorMode.HashAlgorithm)]
        Task PublishAsync(string deviceId, WillMessage message);

        [Command(ShuntStrategy = AddressSelectorMode.HashAlgorithm)]
        Task<bool> IsOnlineAsync(string deviceId);
    }
}
