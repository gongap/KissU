using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Dependency;
using KissU.Modules.Identity.Application.Contracts.Dtos;
using KissU.Modules.Identity.Service.Contracts;
using KissU.ServiceProxy;

namespace KissU.Modules.Identity.Service.Implements
{
    /// <summary>
    /// 授权服务
    /// </summary>
    [ModuleName("Auth")]
    public class AuthService : ProxyServiceBase, IAuthService
    {
        /// <summary>
        /// 获取令牌
        /// </summary>
        /// <param name="parameters">请求参数</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public async Task<Dictionary<string, List<string>>> Token(SignInDto parameters)
        {
            return await GetService<IAccountService>().SignIn(parameters);
        }
    }
}