using System;
using System.Threading.Tasks;
using KissU.Core.Dependency;
using KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using Volo.Abp.Users;

namespace KissU.Modules.Identity.Service.Contracts
{
    [ServiceBundle("api/{Service}")]
    public interface IIdentityUserLookupService : IServiceKey
    {
        [HttpGet(true)]
        [ServiceRoute("{id}")]
        Task<UserData> FindByIdAsync(Guid id);

        [HttpGet(true)]
        [ServiceRoute("by-username/{userName}")]
        Task<UserData> FindByUserNameAsync(string userName);
    }
}