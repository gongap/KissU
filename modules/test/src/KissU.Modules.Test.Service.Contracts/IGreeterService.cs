using Grpc.Core;
using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Dependency;
using System.Threading.Tasks;

namespace KissU.Modules.Test.Service.Contracts
{
    [ServiceBundle("api/{Service}/{Method}")]
    public interface IGreeterService : IServiceKey
    {
        Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context = null);
    }
}
