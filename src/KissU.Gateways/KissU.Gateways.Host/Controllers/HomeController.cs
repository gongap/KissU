using System.Diagnostics;
using KissU.Gateways.Host.Models;
using Microsoft.AspNetCore.Mvc;

namespace KissU.Gateways.Host.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
