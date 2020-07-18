using System.Threading.Tasks;
using KissU.Dependency;
using KissU.Modules.Identity.Application.Contracts;
using KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;

namespace KissU.Services.Identity.Contract
{
    [ServiceBundle("api/{Service}")]
    public interface IProfileService : IServiceKey
    {
        [HttpGet(true)]
        Task<ProfileDto> GetAsync();

        [HttpPut(true)]
        Task<ProfileDto> UpdateAsync(UpdateProfileDto input);

        [HttpPost(true)]
        [ServiceRoute("change-password")]
        Task ChangePasswordAsync(ChangePasswordInput input);
    }
}