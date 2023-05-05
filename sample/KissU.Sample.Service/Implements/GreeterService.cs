using System.Threading.Tasks;
using Grpc.Core;
using KissU.Msm.Sample.Service.Behaviors;
using KissU.Msm.Sample.Service.Contracts;

namespace KissU.Msm.Sample.Service.Implements
{
    public class GreeterService : GreeterBehavior, IGreeterService
    {
        public override Task<HelloReply> SayHelloAsync(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }
    }
}
