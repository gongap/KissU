using System.Threading;
using System.Threading.Tasks;
using KissU.Modules.Test.Service.Contracts;
using KissU.Modules.Test.Service.Contracts.Thrifts.ThriftContracts;
using KissU.ServiceProxy;
using KissU.Thrift.Attributes;

namespace KissU.Modules.Test.Service.Implements
{
    [BindProcessor(typeof(Calculator.AsyncProcessor))]
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
