using System.Threading;
using System.Threading.Tasks;
using KissU.Dependency;
using KissU.Services.SampleA.Contract.Thrifts.ThriftCore;
using KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Surging.CPlatform.Support.Attributes;

namespace KissU.Services.SampleA.Contract
{
    [ServiceBundle("api/{Service}/{Method}")]
    public interface IAsyncService : Calculator.IAsync, IServiceKey
    {
        [Command(ExecutionTimeoutInMilliseconds = 10000)]
        Task<int> @AddAsync(int num1, int num2, CancellationToken cancellationToken = default);

        Task<string> SayHelloAsync(CancellationToken cancellationToken = default);
    }

}
