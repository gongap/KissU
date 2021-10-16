using Greet;
using Grpc.Core;
using KissU.Modules.Common.Service.Behaviors;
using KissU.Modules.Common.Service.Contracts;
using System.Threading.Tasks;

namespace KissU.Modules.Common.Service
{
    public class GreeterService : GreeterBehavior, IGreeterService
    {
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }
    }
}
