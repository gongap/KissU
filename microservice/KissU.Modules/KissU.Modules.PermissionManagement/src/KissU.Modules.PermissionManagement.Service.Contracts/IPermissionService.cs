using System.Threading.Tasks;
using KissU.Dependency;
using KissU.Modules.PermissionManagement.Application.Contracts;
using KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;

namespace KissU.Services.PermissionManagement.Contract
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