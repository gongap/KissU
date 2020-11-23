using System.Threading.Tasks;
using KissU.Dependency;
using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using Volo.Abp.FeatureManagement;

namespace KissU.Modules.FeatureManagement.Service.Contracts
{
    [ServiceBundle("api/{Service}")]
    public interface IFeatureService : IServiceKey
    {
        [HttpGet(true)]
        Task<GetFeatureListResultDto> GetAsync(string providerName, string providerKey);

        [HttpPost(true)]
        Task UpdateAsync(string providerName, string providerKey, UpdateFeaturesDto input);
    }
}