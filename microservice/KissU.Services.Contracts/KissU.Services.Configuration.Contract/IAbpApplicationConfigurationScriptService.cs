using System.Threading.Tasks;
using KissU.Dependency;
using KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;

namespace KissU.Services.Configuration.Contract
{
    [ServiceBundle("Abp/ApplicationConfigurationScript")]
    public interface IAbpApplicationConfigurationScriptService : IServiceKey
    {
        [HttpGet(true)]
        Task<string> Get();
    }
}