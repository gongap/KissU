using System.Threading;
using System.Threading.Tasks;
using KissU.Dependency;
using KissU.Services.SampleA.Contract.Thrifts.ThriftCore;
using KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;

namespace KissU.Services.SampleA.Contract
{
    [ServiceBundle("api/{Service}/{Method}")]
    public interface IThirdAsyncService : ThirdCalculator.IAsync, IServiceKey
    {
        Task<int> @AddAsync(int num1, int num2, CancellationToken cancellationToken = default);

        Task<string> SayHelloAsync(CancellationToken cancellationToken = default);
    }
}