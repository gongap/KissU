using System.Threading.Tasks;
using KissU.CPlatform.Filters.Implementation;
using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.CPlatform.Support.Attributes;
using KissU.Dependency;
using KissU.Modules.Identity.Service.Contracts.Dtos;
using KissU.ServiceProxy.Interceptors.Implementation.Metadatas;
using Volo.Abp.Users;

namespace KissU.Modules.Identity.Service.Contracts
{
    /// <summary>
    /// 用户查询服务
    /// </summary>
    /// <seealso cref="IServiceKey" />
    [ServiceBundle("api/{Service}")]
    public interface IUserLookupService : IServiceKey
    {
        /// <summary>
        /// 查找用户
        /// </summary>
        /// <param name="parameters">查找参数</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Command(RequestCacheEnabled = true)]
        [ServiceCacheIntercept(CachingMethod.Get, Key = "FindUser_{0}", CacheSectionType = "ddlCache", Mode = CacheTargetType.Redis, Time = 480)]
        Task<UserData> FindUser(FindUserInput parameters);

        /// <summary>
        /// 通过Id查询
        /// </summary>
        /// <param name="id">Id标识</param>
        /// <returns>Task&lt;UserData&gt;.</returns>
        [HttpGet(true)]
        [ServiceRoute("{id}")]
        Task<UserData> FindById(string id);

        /// <summary>
        /// 通过用户名查询
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>Task&lt;UserData&gt;.</returns>
        [HttpGet(true)]
        [ServiceRoute("{userName}")]
        Task<UserData> FindByUserName(string userName);
    }
}