using System.Threading;
using System.Threading.Tasks;
using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.CPlatform.Support.Attributes;
using KissU.Dependency;
using KissU.Modules.Test.Service.Contracts.Thrifts.ThriftContracts;

namespace KissU.Modules.Test.Service.Contracts
{
    [ServiceBundle("api/{Service}/{Method}")]
    public interface IAsyncService: Calculator.IAsync,  IServiceKey
    {
       [Command(ExecutionTimeoutInMilliseconds=10000)]
        Task<int> @AddAsync(int num1, int num2, CancellationToken cancellationToken = default(CancellationToken));

        Task<string> SayHelloAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
