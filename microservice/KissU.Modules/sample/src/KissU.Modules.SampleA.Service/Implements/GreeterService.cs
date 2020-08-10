using System.Threading.Tasks;
using Greet;
using Grpc.Core;
using KissU.Modules.SampleA.Service.Behaviors;
using KissU.Modules.SampleA.Service.Contracts;

namespace KissU.Modules.SampleA.Service.Implements
{
    /// <summary>
    /// GreeterService.
    /// Implements the <see cref="KissU.Modules.SampleA.Service.Behaviors.GreeterBehavior" />
    /// Implements the <see cref="IGreeterService" />
    /// </summary>
    /// <seealso cref="KissU.Modules.SampleA.Service.Behaviors.GreeterBehavior" />
    /// <seealso cref="IGreeterService" />
    public class GreeterService : GreeterBehavior, IGreeterService
    {
        /// <summary>
        /// Says the hello.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="context">The context.</param>
        /// <returns>Task&lt;HelloReply&gt;.</returns>
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }
    }
}