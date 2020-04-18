using System;
using System.Threading.Tasks;
using KissU.Core.Dependency;
using KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using Volo.Abp.Users;

namespace Volo.Abp.Identity
{

    [ServiceBundle("api/{Service}")]
    public interface IIdentityUserLookupService : IServiceKey
    {
        [HttpGet]
        [ServiceRoute("{id}")]
        Task<UserData> FindByIdAsync(Guid id);

        [HttpGet]
        [ServiceRoute("by-username/{userName}")]
        Task<UserData> FindByUserNameAsync(string userName);
    }
}
