using Microsoft.AspNetCore.Mvc;

namespace KissU.Controllers {
    /// <summary>
    /// 主控制器
    /// </summary>
    public class HomeController : Controller {
        /// <summary>
        /// 首页
        /// </summary>
        public IActionResult Index() {
            return View("~/Pages/Index.cshtml");
        }
    }
}