using System.Threading.Tasks;
using KissU.Dependency;
using KissU.Modules.Account.Service.Contracts;
using KissU.Modules.Account.Service.Contracts.Models;
using KissU.ServiceProxy;
using Volo.Abp.Users;

namespace KissU.Modules.Account.Service.Implements
{
    /// <summary>
    /// 授权服务
    /// </summary>
    [ModuleName("Mobile")]
    public class AuthService : ProxyServiceBase, IAuthService
    {
        /// <summary>
        /// 获取令牌
        /// </summary>
        /// <param name="parameters">请求参数</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public Task<UserData> Token(AuthDto parameters)
        {
            return Task.FromResult(new UserData
            {
                Id = System.Guid.Parse("33ABC3EE-F993-CB34-D04E-39F7278885BA"), 
                UserName = "admin",
                PhoneNumber = parameters.Mobile
            });
        }
    }
}