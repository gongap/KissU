using System.Threading.Tasks;
using KissU.Modules.Identity.Application.Contracts.Account;
using Volo.Abp.Application.Services;

namespace KissU.Modules.Identity.Application.Contracts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IdentityUserDto> RegisterAsync(RegisterDto input);

        Task<AbpLoginResult> Login(UserLoginInfo login);

        Task Logout();

        Task<AbpLoginResult> CheckPassword(UserLoginInfo login);
    }
}