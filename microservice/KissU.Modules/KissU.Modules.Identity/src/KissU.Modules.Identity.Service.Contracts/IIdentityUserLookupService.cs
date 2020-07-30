using System.Threading.Tasks;
using KissU.Dependency;
using KissU.Modules.Users.Abstractions;
using KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;

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