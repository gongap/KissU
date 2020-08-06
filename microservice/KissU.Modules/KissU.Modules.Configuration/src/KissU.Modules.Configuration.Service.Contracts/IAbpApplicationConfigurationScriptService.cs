using System.Threading.Tasks;
using KissU.Dependency;
using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;

namespace KissU.Modules.Configuration.Service.Contracts
{
    [ServiceBundle("Abp/ApplicationConfigurationScript")]
    public interface IAbpApplicationConfigurationScriptService : IServiceKey
    {
        [HttpGet(true)]
        Task<string> Get();
    }
}