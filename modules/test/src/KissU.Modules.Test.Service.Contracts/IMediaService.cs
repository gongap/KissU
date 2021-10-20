using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Dependency;
using KissU.WebSocket.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KissU.Modules.Test.Service.Contracts
{
    [ServiceBundle("Api/{Service}")]
    [BehaviorContract(IgnoreExtensions =true,Protocol = "media")]
    public interface IMediaService : IServiceKey
    { 
        Task Push(IEnumerable<byte> data);
    }
}
