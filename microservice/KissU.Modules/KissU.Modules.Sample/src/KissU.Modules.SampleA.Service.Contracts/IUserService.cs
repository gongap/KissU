using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Dependency;
using KissU.EventBus.Events;
using KissU.Modules.SampleA.Service.Contracts.Dtos;
using KissU.Caching.Interceptors;
using KissU.CPlatform.Filters.Implementation;
using KissU.CPlatform.Runtime.Client.Address.Resolvers.Implementation.Selectors.Implementation;
using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.CPlatform.Support;
using KissU.CPlatform.Support.Attributes;
using KissU.Kestrel.Abstractions;
using KissU.KestrelHttpServer.Abstractions;
using KissU.KestrelHttpServer.Internal;
using KissU.Models;
using CacheTargetType = KissU.Caching.CacheTargetType;
using CachingMethod = KissU.Caching.Interceptors.CachingMethod;
using Metadatas = KissU.ProxyGenerator.Interceptors.Implementation.Metadatas;

namespace KissU.Modules.SampleA.Service.Contracts
{
    /// <summary>
    /// Interface IAccountService
    /// Implements the <see cref="IServiceKey" />
    /// </summary>
    /// <seealso cref="IServiceKey" />
    [ServiceBundle("api/{Service}/{Method}")]
    //[ServiceBundle("api/{Service}")]
    //[ServiceBundle("api/{Service}/{Method}/test")]
    //[ServiceBundle("api/{Service}/{Method}/test",false)]
    public interface IUserService : IServiceKey
    {
        /// <summary>
        /// 用戶授权
        /// </summary>
        /// <param name="requestData">请求参数</param>
        /// <returns>用户模型</returns>
        Task<UserModel> Authentication(AuthenticationRequestData requestData);

        /// <summary>
        /// 获取用户姓名
        /// </summary>
        /// <param name="id">用户编号</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        [ServiceRoute("{id}")]
        Task<string> GetUserName(int id);

        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="id">用户编号</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        [ServiceRoute("{id}")]
        [HttpPost(true), HttpPut(true), HttpDelete(true), HttpGet(true)]
        // [ServiceBundle("api/{Service}/{id}", false)]
        Task<bool> Exists(int id);

        /// <summary>
        /// 报错用户
        /// </summary>
        /// <param name="requestData">请求参数</param>
        /// <returns>Task&lt;IdentityUser&gt;.</returns>
        [Authorization(AuthType = AuthorizationType.JWT)]
        [HttpPost(true)]
        [HttpPut(true)]
        Task<IdentityUser> Save(IdentityUser requestData);

        /// <summary>
        /// 根据用户名获取用户ID
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        [Authorization(AuthType = AuthorizationType.JWT)]
        [Command(Strategy = StrategyType.Injection, ShuntStrategy = AddressSelectorMode.HashAlgorithm,
            ExecutionTimeoutInMilliseconds = 1500, BreakerRequestVolumeThreshold = 3, Injection = @"return 1;",
            RequestCacheEnabled = false)]
        [InterceptMethod(CachingMethod.Get, Key = "GetUserId_{0}", CacheSectionType = SectionType.ddlCache,
            L2Key = "GetUserId_{0}", EnableL2Cache = true, Mode = CacheTargetType.Redis, Time = 480)]
        [Metadatas.ServiceCacheIntercept(Metadatas.CachingMethod.Get, Key = "GetUserId_{0}", CacheSectionType = "ddlCache", L2Key = "GetUserId_{0}", EnableL2Cache = true, Mode = Metadatas.CacheTargetType.Redis, Time = 480)]
        [Metadatas.ServiceLogIntercept()]
        [ServiceRoute("{userName}")]
        Task<int> GetUserId(string userName);

        /// <summary>
        /// Tries this instance.
        /// </summary>
        /// <returns>Task.</returns>
        Task Try();

        /// <summary>
        /// 获取用户最后次sign时间
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns>Task&lt;DateTime&gt;.</returns>
        Task<DateTime> GetUserLastSignInTime(int id);

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="user">用户模型</param>
        /// <returns>Task&lt;UserModel&gt;.</returns>
        [Command(Strategy = StrategyType.Injection, Injection = @"return
        new KissU.Modules.SampleA.Service.Contracts.Dtos.UserModel
         {
            Name=""gongap"",
            Age=19
         };", RequestCacheEnabled = true, InjectionNamespaces = new[] { "KissU.Modules.SampleA.Service.Contracts.Dtos" })]
        [InterceptMethod(CachingMethod.Get, Key = "GetUser_id_{0}", CacheSectionType = SectionType.ddlCache,Mode = CacheTargetType.Redis, Time = 480)]
        [Metadatas.ServiceCacheIntercept(Metadatas.CachingMethod.Get, Key = "GetUser_{0}_{1}", L2Key = "GetUser_{0}_{1}", EnableL2Cache = true, CacheSectionType = "ddlCache", Mode = Metadatas.CacheTargetType.Redis, Time = 480)]
        Task<UserModel> GetUser(UserModel user);

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <param name="model">用户模型</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        [Authorization(AuthType = AuthorizationType.JWT)]
        [Command(Strategy = StrategyType.FallBack, FallBackName = "UpdateFallBackName", RequestCacheEnabled = true,
            InjectionNamespaces = new[] { "KissU.Modules.SampleA.Service.Contracts" })]
        [InterceptMethod(CachingMethod.Remove, "GetUser_id_{0}", "GetUserName_name_{0}",
            CacheSectionType = SectionType.ddlCache, Mode = CacheTargetType.Redis)]
        Task<bool> Update(int id, UserModel model);

        /// <summary>
        /// 测试List参数调用
        /// </summary>
        /// <param name="users">用户列表</param>
        /// <returns>返回是否成功</returns>
        Task<bool> Get(List<UserModel> users);

        /// <summary>
        /// 测试无参数调用
        /// </summary>
        /// <returns>返回是否成功</returns>
        [Command(Strategy = StrategyType.Injection, ShuntStrategy = AddressSelectorMode.Polling,
            ExecutionTimeoutInMilliseconds = 1500, BreakerRequestVolumeThreshold = 3, Injection = @"return false;",
            FallBackName = "GetDictionaryMethodBreaker", RequestCacheEnabled = false)]
        [InterceptMethod(CachingMethod.Get, Key = "GetDictionary", CacheSectionType = SectionType.ddlCache,
            Mode = CacheTargetType.Redis, Time = 480)]
        Task<bool> GetDictionary();

        /// <summary>
        /// 测试异常
        /// </summary>
        /// <returns>Task.</returns>
        Task TryThrowException();

        /// <summary>
        /// Sets the sex.
        /// </summary>
        /// <param name="sex">The sex.</param>
        /// <returns>Task&lt;Sex&gt;.</returns>
        [ServiceRoute("{sex}")]
        Task<Sex> SetSex(Sex sex);

        /// <summary>
        /// 测试基于eventbus 推送消息
        /// </summary>
        /// <param name="evt1">Event 模型</param>
        /// <returns>Task.</returns>
        Task PublishThroughEventBusAsync(IntegrationEvent evt1);

        /// <summary>
        /// 测试无参调用，返回泛型结果
        /// </summary>
        /// <returns>Task&lt;ApiResult&lt;UserModel&gt;&gt;.</returns>
        [Command(Strategy = StrategyType.Injection, ShuntStrategy = AddressSelectorMode.HashAlgorithm,
            ExecutionTimeoutInMilliseconds = 2500, BreakerRequestVolumeThreshold = 3, Injection = @"return null;",
            RequestCacheEnabled = false)]
        Task<ApiResult<UserModel>> GetApiResult();

        /// <summary>
        /// 测试参数list参数
        /// </summary>
        /// <param name="idList">list 类型参数</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        [ServiceMetadata("IsOverload", true)]
        Task<string> GetUser(List<int> idList);

        /// <summary>
        /// 测序guid
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;UserModel&gt;.</returns>
        [ServiceRoute("{id}")]
        Task<UserModel> GetUserById(Guid id);

        /// <summary>
        /// 测试上传文件
        /// </summary>
        /// <param name="form">HttpFormCollection 类型参数</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> UploadFile(HttpFormCollection form);

        /// <summary>
        /// 测试下载文件
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="contentType">Content-Type</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        [ServiceRoute("{fileName}/{contentType}")]
        Task<IActionResult> DownFile(string fileName, string contentType);

        /// <summary>
        /// Gets all things.
        /// </summary>
        /// <returns>Task&lt;Dictionary&lt;System.String, System.Object&gt;&gt;.</returns>
        Task<Dictionary<string, object>> GetAllThings();

        [Metadatas.ServiceCacheIntercept(Metadatas.CachingMethod.Remove, "GetUser_{0}_{1}", CacheSectionType = "ddlCache", Mode = Metadatas.CacheTargetType.Redis)]
        Task<bool> RemoveUser(UserModel user);
    }
}