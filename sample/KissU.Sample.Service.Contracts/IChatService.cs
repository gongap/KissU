using System.Threading.Tasks;
using KissU.CPlatform.Runtime.Client.Address.Resolvers.Implementation.Selectors.Implementation;
using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.CPlatform.Support.Attributes;
using KissU.Dependency;
using KissU.WebSocket.Attributes;

namespace KissU.Msm.Sample.Service.Contracts
{
    [ServiceBundle("api/{Service}/{Async}")]
    [BehaviorContract(IgnoreExtensions = true)]
    public interface IChatService : IServiceKey
    {
        [Command(ShuntStrategy = AddressSelectorMode.HashAlgorithm)]
        Task SendMessageAsync(string name, string data);
    }
}
