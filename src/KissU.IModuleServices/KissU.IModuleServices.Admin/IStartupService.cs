using Surging.Core.CPlatform.Ioc;
using Surging.Core.CPlatform.Runtime.Client.Address.Resolvers.Implementation.Selectors.Implementation;
using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using Surging.Core.CPlatform.Support;
using Surging.Core.CPlatform.Support.Attributes;
using System.Threading.Tasks;
using GreatWall.Service.Dtos.NgAlain;
using Surging.Core.CPlatform.Filters.Implementation;

namespace Surging.IModuleServices.User
{

    [ServiceBundle("api/{Service}")]
    public interface IStartupService : IServiceKey
    {
        [Command(Strategy = StrategyType.Injection, ShuntStrategy = AddressSelectorMode.HashAlgorithm, ExecutionTimeoutInMilliseconds = 2500, BreakerRequestVolumeThreshold = 3, Injection = @"return 1;", RequestCacheEnabled = false)]
        [HttpGet(true)]
        //[Authorization(AuthType = AuthorizationType.JWT)]
        Task<AppData> GetAppDataAsync();
    }
}
