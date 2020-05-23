using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using KissU.Core.Dependency;
using KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Surging.CPlatform.Support.Attributes;

namespace KissU.Modules.SampleA.Service.Contracts
{
    [ServiceBundle("api/{Service}/{Method}")]
    public interface IAsyncService : ThriftCore.Calculator.IAsync, IServiceKey
    {
        [Command(ExecutionTimeoutInMilliseconds = 10000)]
        Task<int> @AddAsync(int num1, int num2, CancellationToken cancellationToken = default);

        Task<string> SayHelloAsync(CancellationToken cancellationToken = default);
    }

}
