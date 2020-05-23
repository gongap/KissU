using System.Threading;
using System.Threading.Tasks;
using KissU.Core.Dependency;
using KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;

namespace KissU.Modules.SampleA.Service.Contracts
{
    [ServiceBundle("api/{Service}/{Method}")]
    public interface IThirdAsyncService : ThriftCore.ThirdCalculator.IAsync, IServiceKey
    {
        Task<int> @AddAsync(int num1, int num2, CancellationToken cancellationToken = default);

        Task<string> SayHelloAsync(CancellationToken cancellationToken = default);
    }
}