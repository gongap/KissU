using System.Threading.Tasks;
using KissU.CPlatform.Runtime.Client.Address.Resolvers.Implementation.Selectors.Implementation;
using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.CPlatform.Support;
using KissU.CPlatform.Support.Attributes;
using KissU.Dependency;

namespace KissU.Msm.Sample.Service.Contracts
{
    [ServiceBundle("api/{Service}/{Async}")]
    public interface IManagerService : IServiceKey
    {
        [Command(Strategy = StrategyType.Injection, ShuntStrategy = AddressSelectorMode.HashAlgorithm, ExecutionTimeoutInMilliseconds = 2500, BreakerRequestVolumeThreshold = 3, Injection = @"return 1;", RequestCacheEnabled = false)]
        Task<string> SayHelloAsync(string name);

        [Reactive]
        public Task<int> ReactiveTestAsync(int value);
    }
}
