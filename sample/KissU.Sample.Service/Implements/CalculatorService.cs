using System.Threading;
using System.Threading.Tasks;
using KissU.ServiceProxy;
using KissU.Thrift.Attributes;
using KissU.Msm.Sample.Service.Contracts;
using KissU.Msm.Sample.Service.Contracts.Thrifts.gen_netstd.ThriftContracts;

namespace KissU.Msm.Sample.Service.Implements
{
    [BindProcessor(typeof(Calculator.AsyncProcessor))]
    public class CalculatorService : ProxyServiceBase, ICalculatorService
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
