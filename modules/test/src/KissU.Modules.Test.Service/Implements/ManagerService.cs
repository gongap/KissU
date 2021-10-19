using System.Threading.Tasks;
using KissU.Modules.Identity.Service.Contracts;
using KissU.Modules.Test.Service.Contracts;
using KissU.ServiceProxy;
using Microsoft.Extensions.Logging;

namespace KissU.Modules.Test.Service.Implements
{
    public class ManagerService : ProxyServiceBase, IManagerService
    {
        private readonly ILogger<ManagerService> _logger;

        public ManagerService(ILogger<ManagerService> logger)
        {
            _logger = logger;
        }

        public async Task<string> SayHello(string name)
        {
           var roleList = await base.GetService<IRoleService>().GetAllList();
           if (roleList?.Items?.Count > 0)
           {
               foreach (var role in roleList.Items)
               {
                   _logger.LogDebug(role.ToString());
               }
            }

            return $"{name} say:hello";
        }
    }
}
