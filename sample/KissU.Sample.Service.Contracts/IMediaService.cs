using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Dependency;
using KissU.WebSocket.Attributes;

namespace KissU.Msm.Sample.Service.Contracts
{
    [ServiceBundle("api/{Service}/{Async}")]
    [BehaviorContract(IgnoreExtensions =true,Protocol = "media")]
    public interface IMediaService : IServiceKey
    { 
        Task PushAsync(IEnumerable<byte> data);
    }
}
