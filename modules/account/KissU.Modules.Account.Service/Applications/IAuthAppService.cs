using System.Security.Claims;
using System.Threading.Tasks;
using KissU.Modules.Account.Service.Contracts.Models;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace KissU.Modules.Account.Service.Applications
{
    public interface IAuthAppService : IApplicationService, IRemoteService
    {
        Task<ClaimsPrincipal> AuthAsync(AuthDto input);
    }
}