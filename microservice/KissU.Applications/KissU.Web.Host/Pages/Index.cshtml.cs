using KissU.Surging.ProxyGenerator;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace KissU.Web.Host.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly TestService testService;
        private readonly IServiceProxyFactory serviceProxyFactory;

        public IndexModel(ILogger<IndexModel> logger, TestService testService, IServiceProxyFactory serviceProxyFactory)
        {
            _logger = logger;
            this.testService = testService;
            this.serviceProxyFactory = serviceProxyFactory;
        }

        public void OnGet()
        {
            testService.Test(serviceProxyFactory);
        }
    }
}