using System.Threading.Tasks;
using KissU.Core.Dependency;
using KissU.Surging.ProxyGenerator;
using KissU.Modules.FeatureManagement.Service.Contracts;

namespace KissU.Modules.FeatureManagement.Service.Implements
{
    [ModuleName(FeatureManagementRemoteServiceConsts.RemoteServiceName)]
    public class FeatureService : ProxyServiceBase, IFeatureService
    {
        private readonly IFeatureAppService _permissionAppService;

        public FeatureService(IFeatureAppService permissionAppService)
        {
            _permissionAppService = permissionAppService;
        }

        public virtual Task<FeatureListDto> GetAsync(string providerName, string providerKey)
        {
            return _permissionAppService.GetAsync(providerName, providerKey);
        }

        public virtual Task UpdateAsync(string providerName, string providerKey, UpdateFeaturesDto input)
        {
            return _permissionAppService.UpdateAsync(providerName, providerKey, input);
        }
    }
}