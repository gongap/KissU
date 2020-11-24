using System.Threading.Tasks;
using KissU.Dependency;
using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using Volo.Abp.Identity;
using Volo.Abp.Account;

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