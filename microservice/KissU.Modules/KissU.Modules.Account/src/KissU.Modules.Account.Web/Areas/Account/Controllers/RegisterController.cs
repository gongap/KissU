using System.Threading.Tasks;
using KissU.Modules.Account.Application.Contracts;
using KissU.Modules.Identity.Application.Contracts;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace KissU.Modules.Account.Web.Areas.Account.Controllers
{
    [Area("account")]
    [Route("api/account")]
    public class RegisterController : AbpController
    {
        protected IAccountAppService AccountAppService { get; }

        public RegisterController(IAccountAppService accountAppService)
        {
            AccountAppService = accountAppService;
        }

        [HttpPost]
        [Route("register")]
        public virtual Task<IdentityUserDto> RegisterAsync(RegisterDto input)
        {
            return AccountAppService.RegisterAsync(input);
        }
    }
}