using System.Threading.Tasks;
using KissU.Core.CPlatform.Address;
using KissU.Core.CPlatform.Ioc;
using KissU.Core.CPlatform.Runtime.Client.Address.Resolvers.Implementation.Selectors.Implementation;
using KissU.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Core.CPlatform.Support.Attributes;

namespace KissU.Core.CPlatform.Module
{
    [ServiceBundle("")]
    public interface IEchoService: IServiceKey
    {
        [Command(ShuntStrategy = AddressSelectorMode.HashAlgorithm)]
        Task<IpAddressModel> Locate(string key,string routePath);
    }
}
