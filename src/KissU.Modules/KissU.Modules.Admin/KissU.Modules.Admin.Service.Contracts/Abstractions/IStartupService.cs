using System.Threading.Tasks;
using KissU.Core.CPlatform.Ioc;
using KissU.Core.CPlatform.Runtime.Client.Address.Resolvers.Implementation.Selectors.Implementation;
using KissU.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Core.CPlatform.Support;
using KissU.Core.CPlatform.Support.Attributes;
using KissU.Modules.Admin.Service.Contracts.Dtos.NgAlain;
using KissU.Util.Applications;

namespace KissU.Modules.Admin.Service.Contracts.Abstractions
{
    /// <summary>
    /// Interface IStartupService
    /// Implements the <see cref="KissU.Util.Applications.IService" />
    /// </summary>
    /// <seealso cref="KissU.Util.Applications.IService" />
    [ServiceBundle("api/{Service}")]
    public interface IStartupService : IServiceKey
    {
        /// <summary>
        /// 获取应用程序数据
        /// </summary>
        /// <returns>Task&lt;AppData&gt;.</returns>
        [Command(Strategy = StrategyType.Injection, ShuntStrategy = AddressSelectorMode.HashAlgorithm,
            ExecutionTimeoutInMilliseconds = 2500, BreakerRequestVolumeThreshold = 3, Injection = @"return 1;",
            RequestCacheEnabled = false)]
        [HttpGet(true)]
        //[Authorization(AuthType = AuthorizationType.JWTBearer)]
        Task<AppData> GetAppDataAsync();
    }
}