using System.Threading.Tasks;
using KissU.CPlatform.Runtime.Client.Address.Resolvers.Implementation.Selectors.Implementation;
using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.CPlatform.Support.Attributes;
using KissU.Dependency;
using KissU.Modules.Test.Service.Contracts.Models;

namespace KissU.Modules.Test.Service.Contracts
{
    [ServiceBundle("Device/{Service}")] 
    public interface IControllerService : IServiceKey
    { 
        [Command(ShuntStrategy = AddressSelectorMode.HashAlgorithm)]
        Task Publish(string deviceId, WillMessage message);

        [Command(ShuntStrategy = AddressSelectorMode.HashAlgorithm)]
        Task<bool> IsOnline(string deviceId);
    }
}
