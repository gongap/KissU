﻿using System.Threading.Tasks;
using KissU.Caching;
using KissU.CPlatform.Cache;
using KissU.Modules.Identity.Service.Contracts;
using KissU.ServiceProxy;
using Volo.Abp.Identity;
using Volo.Abp.Users;

namespace KissU.Modules.Identity.Service.Implements
{
    /// <summary>
    /// 用户信息
    /// Implements the <see cref="ProxyServiceBase" />
    /// Implements the <see cref="IProfileService" />
    /// </summary>
    /// <seealso cref="ProxyServiceBase" />
    /// <seealso cref="IProfileService" />
    public class ProfileService : ProxyServiceBase, IProfileService
    {
        private readonly IProfileAppService _appService;
        private readonly ICurrentUser _currentUser;
        private readonly ICacheProvider _cacheProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfileService"/> class.
        /// </summary>
        /// <param name="appService">The application service.</param>
        public ProfileService(IProfileAppService appService, ICurrentUser currentUser)
        {
            _appService = appService;
            _currentUser = currentUser;
            _cacheProvider = CacheContainer.GetService<ICacheProvider>("userCache.Redis");
        }

        /// <summary>
        /// 获取基本信息
        /// </summary>
        /// <returns>Task&lt;ProfileDto&gt;.</returns>
        public virtual Task<ProfileDto> Get()
        {
            return _appService.GetAsync();
        }

        /// <summary>
        /// 更新基本信息
        /// </summary>
        /// <param name="parameters">请求参数</param>
        /// <returns>Task&lt;ProfileDto&gt;.</returns>
        public async Task<ProfileDto> Update(UpdateProfileDto parameters)
        {
            var result = await _appService.UpdateAsync(parameters);
            _cacheProvider.RemoveAsync(string.Format("FindById_{0}", _currentUser.GetId()));
            _cacheProvider.RemoveAsync(string.Format("FindByUserName_{0}", result.UserName));
            return result;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="parameters">请求参数</param>
        /// <returns>Task.</returns>
        public async Task ChangePassword(ChangePasswordInput parameters)
        {
            await _appService.ChangePasswordAsync(parameters);
        }
    }
}