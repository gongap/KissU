using System.Threading.Tasks;
using Greet;
using Grpc.Core;
using KissU.Surging.CPlatform.Ioc;
using KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;

namespace KissU.Modules.SampleA.Service.Contracts
{
    /// <summary>
    /// Interface IGreeterService
    /// Implements the <see cref="KissU.Surging.CPlatform.Ioc.IServiceKey" />
    /// </summary>
    /// <seealso cref="KissU.Surging.CPlatform.Ioc.IServiceKey" />
    [ServiceBundle("api/{Service}/{Method}")]
    public interface IGreeterService : IServiceKey
    {
        /// <summary>
        /// Says the hello.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="context">The context.</param>
        /// <returns>Task&lt;HelloReply&gt;.</returns>
        Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context = null);
    }
}