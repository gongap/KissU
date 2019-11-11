using System.Threading.Tasks;
using IdentityServer4.Services;
using KissU.Authentication.Attributes;
using KissU.Authentication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace KissU.Authentication.Controllers
{
    /// <summary>
    /// 主控制器
    /// </summary>
    [SecurityHeaders]
    public class HomeController : Controller
    {
        /// <summary>
        /// 初始化主控制器
        /// </summary>
        /// <param name="interaction">交互服务</param>
        public HomeController(IIdentityServerInteractionService interaction)
        {
            InteractionService = interaction;
        }

        /// <summary>
        /// 交互服务
        /// </summary>
        public IIdentityServerInteractionService InteractionService { get; set; }

        /// <summary>
        /// 首页
        /// </summary>
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var localAddresses = new string[] { "127.0.0.1", "::1", HttpContext.Connection.LocalIpAddress.ToString() };
            if (!localAddresses.Contains(HttpContext.Connection.RemoteIpAddress.ToString()))
            {
                return Redirect("~/.well-known/openid-configuration");
            }
            var model = new DiagnosticsViewModel(await HttpContext.AuthenticateAsync());
            return View(model);
        }

        /// <summary>
        /// 错误页
        /// </summary>
        public async Task<IActionResult> Error(string errorId)
        {
            var model = new ErrorViewModel();
            var message = await InteractionService.GetErrorContextAsync(errorId);
            if (message != null)
                model.Error = message;
            return View("Error", model);
        }
    }
}
