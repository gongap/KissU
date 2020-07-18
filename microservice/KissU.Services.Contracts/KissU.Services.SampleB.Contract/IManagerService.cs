using System.Threading.Tasks;
using KissU.Dependency;
using KissU.Surging.CPlatform.Runtime.Client.Address.Resolvers.Implementation.Selectors.Implementation;
using KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Surging.CPlatform.Support;
using KissU.Surging.CPlatform.Support.Attributes;

namespace KissU.Services.SampleB.Contract
{
    /// <summary>
    /// Interface IManagerService
    /// Implements the <see cref="IServiceKey" />
    /// </summary>
    /// <seealso cref="IServiceKey" />
    [ServiceBundle("api/{Service}")]
    public interface IManagerService : IServiceKey
    {
        /// <summary>
        /// Says the hello.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        [Command(Strategy = StrategyType.Injection, ShuntStrategy = AddressSelectorMode.HashAlgorithm,
            ExecutionTimeoutInMilliseconds = 2500, BreakerRequestVolumeThreshold = 3, Injection = @"return 1;",
            RequestCacheEnabled = false)]
        [HttpGet]
        Task<string> SayHello(string name);
    }
}