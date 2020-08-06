using System.Threading.Tasks;
using KissU.Dependency;
using KissU.Modules.Account.Application.Contracts;
using KissU.Modules.Identity.Application.Contracts;
using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;

namespace KissU.Modules.Account.Service.Contracts
{
    [ServiceBundle("api/{Service}")]
    public interface IAccountService : IServiceKey
    {
        [HttpPost(true)]
        [ServiceRoute("register")]
        Task<IdentityUserDto> RegisterAsync(RegisterDto input);
    }
}