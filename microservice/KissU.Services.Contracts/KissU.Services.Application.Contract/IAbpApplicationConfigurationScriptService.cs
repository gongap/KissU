using System.Threading.Tasks;
using KissU.Dependency;
using KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;

namespace KissU.Modules.Application.Service.Contracts
{
    [ServiceBundle("Abp/ApplicationConfigurationScript")]
    public interface IAbpApplicationConfigurationScriptService : IServiceKey
    {
        [HttpGet(true)]
        Task<string> Get();
    }
}