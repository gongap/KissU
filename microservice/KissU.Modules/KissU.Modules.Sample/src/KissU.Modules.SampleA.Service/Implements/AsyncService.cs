using System.Threading;
using System.Threading.Tasks;
using KissU.Modules.SampleA.Service.Contracts;
using KissU.Surging.ProxyGenerator;
using KissU.Surging.Thrift.Attributes;
using static KissU.Modules.SampleA.Service.Contracts.Thrifts.ThriftCore.Calculator;

namespace KissU.Modules.SampleA.Service.Implements
{
    [BindProcessor(typeof(AsyncProcessor))]
    public class AsyncService : ProxyServiceBase, IAsyncService
    {
        public Task<int> AddAsync(int num1, int num2, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(num1 + num2);
        }

        public Task<string> SayHelloAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult("hello world");
        }
    }
}