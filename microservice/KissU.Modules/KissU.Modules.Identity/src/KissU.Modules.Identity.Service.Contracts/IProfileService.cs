using System.Threading.Tasks;
using KissU.Core.Dependency;
using KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using Volo.Abp.Identity;

namespace KissU.Modules.Identity.Service.Contracts
{

    [ServiceBundle("api/{Service}")]
    public interface IProfileService : IServiceKey
    {
        [HttpGet(true)]
        Task<ProfileDto> GetAsync();

        [HttpPut]
        Task<ProfileDto> UpdateAsync(UpdateProfileDto input);

        [HttpPost]
        [ServiceRoute("change-password")]
        Task ChangePasswordAsync(ChangePasswordInput input);
    }
}
