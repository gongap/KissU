using System.Threading.Tasks;
using KissU.Dependency;
using KissU.Modules.PermissionManagement.Application.Contracts;
using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;

namespace KissU.Modules.PermissionManagement.Service.Contracts
{
    [ServiceBundle("api/{Service}")]
    public interface IPermissionService : IServiceKey
    {
        [HttpGet(true)]
        Task<GetPermissionListResultDto> GetAsync(string providerName, string providerKey);

        [HttpPost(true)]
        Task UpdateAsync(string providerName, string providerKey, UpdatePermissionsDto input);
    }
}