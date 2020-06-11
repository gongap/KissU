using System.Threading.Tasks;
using KissU.Dependency;
using KissU.Modules.Account.Application.Contracts;
using KissU.Modules.Account.Application.Contracts.Models;
using KissU.Modules.Identity.Application.Contracts;
using KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;

namespace KissU.Modules.Account.Service.Contracts
{
    [ServiceBundle("api/{Service}")]
    public interface IAccountService : IServiceKey
    {
        [HttpPost(true)]
        [ServiceRoute("register")]
        Task<IdentityUserDto> RegisterAsync(RegisterDto input);

        [HttpPost(true)]
        [ServiceRoute("login")]
        Task<AbpLoginResult> Login(UserLoginInfo login);

        [HttpGet(true)]
        [ServiceRoute("logout")]
        Task Logout();

        [HttpPost(true)]
        [ServiceRoute("checkPassword")]
        Task<AbpLoginResult> CheckPassword(UserLoginInfo login);
    }
}