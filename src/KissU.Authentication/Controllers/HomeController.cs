using System.Threading.Tasks;
using IdentityServer4.Services;
using KissU.Authentication.Attributes;
using KissU.Authentication.Models;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Index()
        {
            return View();
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