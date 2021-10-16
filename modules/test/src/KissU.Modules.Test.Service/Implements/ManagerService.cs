using System.Threading.Tasks;
using KissU.Modules.Test.Service.Contracts;
using KissU.ServiceProxy;

namespace KissU.Modules.Test.Service.Implements
{
    public class ManagerService : ProxyServiceBase, IManagerService
    {
        public Task<string> SayHello(string name)
        {
            return Task.FromResult($"{name} say:hello");
        }
    }
}
