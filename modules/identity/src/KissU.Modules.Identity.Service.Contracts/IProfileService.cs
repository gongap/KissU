using System.Threading.Tasks;
using KissU.CPlatform.Filters.Implementation;
using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Dependency;
using Volo.Abp.Identity;

namespace KissU.Modules.Identity.Service.Contracts
{
    /// <summary>
    /// 用户信息
    /// </summary>
    [ServiceBundle("api/{Service}")]
    public interface IProfileService : IServiceKey
    {
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns>Task&lt;ProfileDto&gt;.</returns>
        [HttpGet(true)]
        [Authorization(AuthType = AuthorizationType.JwtSecret)]
        Task<ProfileDto> Get();

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="parameters">请求参数</param>
        /// <returns>Task&lt;ProfileDto&gt;.</returns>
        [HttpPost(true)]
        [Authorization(AuthType = AuthorizationType.JwtSecret)]
        ////[Command(RequestCacheEnabled = true)]
        ////[ServiceCacheIntercept(CachingMethod.Remove, CorrespondingKeys = new []{ "FindById_{0}" }, CacheSectionType = "userCache", Mode = CacheTargetType.Redis)]
        Task<ProfileDto> Update(UpdateProfileDto parameters);

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="parameters">请求参数</param>
        /// <returns>Task.</returns>
        [HttpPost(true)]
        [Authorization(AuthType = AuthorizationType.JwtSecret)]
        Task ChangePassword(ChangePasswordInput parameters);
    }
}