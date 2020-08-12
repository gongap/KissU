using System.Threading;
using System.Threading.Tasks;
using KissU.Dependency;
using KissU.Modules.SampleA.Service.Contracts.Thrifts.ThriftCore;
using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.CPlatform.Support.Attributes;

namespace KissU.Modules.SampleA.Service.Contracts
{
    [ServiceBundle("api/{Service}/{Method}")]
    public interface IAsyncService : Calculator.IAsync, IServiceKey
    {
        [Command(ExecutionTimeoutInMilliseconds = 10000)]
        Task<int> @AddAsync(int num1, int num2, CancellationToken cancellationToken = default);

        Task<string> SayHelloAsync(CancellationToken cancellationToken = default);
    }

}
