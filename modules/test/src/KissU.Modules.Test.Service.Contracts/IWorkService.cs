using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using System.Threading.Tasks;
using KissU.Dependency;
using KissU.Modules.Test.Service.Contracts.Models;

namespace KissU.Modules.Test.Service.Contracts
{
    [ServiceBundle("Background/{Service}")]
    public interface IWorkService : IServiceKey
    {
        Task<bool> AddWork(Message message);

         Task StartAsync();

        Task StopAsync();
    }
}
