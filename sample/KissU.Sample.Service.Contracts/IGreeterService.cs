using System.Threading.Tasks;
using Grpc.Core;
using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Dependency;

namespace KissU.Msm.Sample.Service.Contracts
{
    [ServiceBundle("api/{Service}//{Async}")]
    public interface IGreeterService : IServiceKey
    {
        Task<HelloReply> SayHelloAsync(HelloRequest request, ServerCallContext context = null);
    }
}
