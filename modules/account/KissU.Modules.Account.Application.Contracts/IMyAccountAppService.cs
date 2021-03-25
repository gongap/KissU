using System.Security.Claims;
using System.Threading.Tasks;
using KissU.Modules.Account.Application.Contracts.Models;
using Volo.Abp.Account;

namespace KissU.Modules.Account.Application.Contracts
{
    public interface IMyAccountAppService : IAccountAppService
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="input">The parameters.</param>
        /// <returns>Task&lt;ClaimsPrincipal&gt;.</returns>
        Task<ClaimsPrincipal> SignInAsync(SignInDto input);
    }
}