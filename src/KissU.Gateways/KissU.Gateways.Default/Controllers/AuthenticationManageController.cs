using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Surging.Core.ApiGateWay.ServiceDiscovery;
using Surging.Core.ApiGateWay.Utilities;
using Surging.Core.CPlatform.Address;

namespace KissU.Gateways.Default.Controllers
{
    public class AuthenticationManageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> EditServiceToken([FromServices]IServiceDiscoveryProvider serviceDiscoveryProvider, string address)
        {
            var list = await serviceDiscoveryProvider.GetAddressAsync(address); ;
            return View(list.FirstOrDefault());
        }

        [HttpPost]
        public async Task<IActionResult> EditServiceToken([FromServices]IServiceDiscoveryProvider serviceDiscoveryProvider, IpAddressModel model)
        {
           await serviceDiscoveryProvider.EditServiceToken(model);
            return Json(ServiceResult.Create(true));
        }
    }
}
