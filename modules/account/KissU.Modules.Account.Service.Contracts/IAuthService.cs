using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Dependency;
using KissU.Modules.Account.Service.Contracts.Models;
using Volo.Abp.Users;

namespace KissU.Modules.Account.Service.Contracts
{
    /// <summary>
    /// 授权服务
    /// </summary>
    [ServiceBundle("api/{Service}")]
    public interface IAuthService : IServiceKey
    {
        /// <summary>
        /// 获取令牌
        /// </summary>
        /// <param name="parameters">请求参数</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        Task<Dictionary<string, List<string>>> Token(AuthDto parameters);
    }
}