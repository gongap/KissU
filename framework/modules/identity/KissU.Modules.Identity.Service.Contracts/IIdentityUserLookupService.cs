﻿using System.Threading.Tasks;
using KissU.Dependency;
using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using Volo.Abp.Users;

namespace KissU.Modules.Identity.Service.Contracts
{
    [ServiceBundle("api/{Service}")]
    public interface IIdentityUserLookupService : IServiceKey
    {
        [HttpGet(true)]
        [ServiceRoute("{id}")]
        Task<UserData> FindByIdAsync(string id);

        [HttpGet(true)]
        [ServiceRoute("by-username/{userName}")]
        Task<UserData> FindByUserNameAsync(string userName);
    }
}