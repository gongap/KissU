using System.Threading.Tasks;
using KissU.Models;
using KissU.Modules.Account.Service.Contracts;
using KissU.ServiceProxy;
using Volo.Abp.Identity;

namespace KissU.Modules.Account.Service.Implements
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
        private readonly IMyProfileAppService _appService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfileService"/> class.
        /// </summary>
        /// <param name="appService">The application service.</param>
        public ProfileService(IMyProfileAppService appService)
        {
            _appService = appService;
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
        public Task<ProfileDto> Update(UpdateProfileDto parameters)
        {
            return _appService.UpdateAsync(parameters);
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

        public Task<string> GetMark()
        {
            return Task.FromResult("爬山");
        }

        public Task<bool> SetMark(string mark)
        {
            return Task.FromResult(true);
        }

        public  Task<ListResult<string>> GetDevices()
        {
            return Task.FromResult(new ListResult<string>(null));
        }

        public  Task<bool> Binding(string device)
        {
            return Task.FromResult(true);
        }

        public  Task<bool> Unbundling(string device)
        {
            return Task.FromResult(true);
        }

        public  Task<ListResult<string>> GetTrails()
        {
            return Task.FromResult(new ListResult<string>(null));
        }

        public  Task<ListResult<string>> GetHisTrails(string hisId)
        {
            return Task.FromResult(new ListResult<string>(null));
        }
    }
}