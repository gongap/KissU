﻿using System.Threading.Tasks;
using KissU.Dependency;
using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using Volo.Abp.Identity;

namespace KissU.Modules.Identity.Service.Contracts
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