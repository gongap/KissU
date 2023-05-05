using System.Threading.Tasks;
using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Dependency;
using KissU.Msm.Sample.Service.Contracts.Models;

namespace KissU.Msm.Sample.Service.Contracts
{
    [ServiceBundle("Background/{Service}/{Async}")]
    public interface IBackgroundService : IServiceKey
    {
        Task<bool> AddWorkAsync(Message message);

         Task StartAsync();

        Task StopAsync();
    }
}
