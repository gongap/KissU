using System.Threading.Tasks;
using Grpc.Core;
using KissU.Modules.Test.Service.Behaviors;
using KissU.Modules.Test.Service.Contracts;

namespace KissU.Modules.Test.Service.Implements
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
