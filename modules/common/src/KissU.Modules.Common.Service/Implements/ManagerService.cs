using System.Threading.Tasks;
using KissU.Modules.Common.Service.Contracts;
using KissU.ServiceProxy;

namespace KissU.Modules.Common.Service.Implements
{
    public class ManagerService : ProxyServiceBase, IManagerService
    {
        public Task<string> SayHello(string name)
        {
            return Task.FromResult($"{name} say:hello");
        }
    }
}
