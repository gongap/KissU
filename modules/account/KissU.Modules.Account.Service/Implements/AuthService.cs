using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissU.Dependency;
using KissU.Modules.Account.Application.Contracts;
using KissU.Modules.Account.Application.Contracts.Models;
using KissU.Modules.Account.Service.Contracts;
using KissU.ServiceProxy;

namespace KissU.Modules.Account.Service.Implements
{
    /// <summary>
    /// 授权服务
    /// </summary>
    [ModuleName("Auth")]
    public class AuthService : ProxyServiceBase, IAuthService
    {
        private readonly IAuthAppService _authAppService;

        public AuthService(IAuthAppService authAppService)
        {
            _authAppService = authAppService;
        }

        /// <summary>
        /// 获取令牌
        /// </summary>
        /// <param name="parameters">请求参数</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public async Task<Dictionary<string, List<string>>> Token(AuthDto parameters)
        {
            var claimsPrincipal = await _authAppService.AuthAsync(parameters);
            return claimsPrincipal?.Identities.SelectMany(x => x.Claims).GroupBy(x => x.Type).ToDictionary(y => y.Key, m => m.Select(n => n.Value).ToList());
        }
    }
}