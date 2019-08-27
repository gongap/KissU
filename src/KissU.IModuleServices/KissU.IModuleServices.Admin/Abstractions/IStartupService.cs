using System.Threading.Tasks;
using KissU.IModuleServices.Admin.Dtos.NgAlain;
using Surging.Core.CPlatform.Filters.Implementation;
using Surging.Core.CPlatform.Runtime.Client.Address.Resolvers.Implementation.Selectors.Implementation;
using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using Surging.Core.CPlatform.Support;
using Surging.Core.CPlatform.Support.Attributes;
using Util.Applications;

namespace KissU.IModuleServices.Admin.Abstractions
{
    [ServiceBundle("api/{Service}")]
    public interface IStartupService : IService
    {
        /// <summary>
        /// 获取应用程序数据
        /// </summary>
        /// <returns></returns>
        [Command(Strategy = StrategyType.Injection, ShuntStrategy = AddressSelectorMode.HashAlgorithm,  ExecutionTimeoutInMilliseconds = 2500, BreakerRequestVolumeThreshold = 3, Injection = @"return 1;", RequestCacheEnabled = false)]
        [HttpGet(true)]
        [Authorization(AuthType = AuthorizationType.JWTBearer)]
        Task<AppData> GetAppDataAsync();
    }
}