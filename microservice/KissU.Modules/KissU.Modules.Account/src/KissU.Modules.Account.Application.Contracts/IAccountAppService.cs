using System.Threading.Tasks;
using KissU.Modules.Account.Application.Contracts.Models;
using KissU.Modules.Identity.Application.Contracts;
using Volo.Abp.Application.Services;

namespace KissU.Modules.Account.Application.Contracts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IdentityUserDto> RegisterAsync(RegisterDto input);
    }
}