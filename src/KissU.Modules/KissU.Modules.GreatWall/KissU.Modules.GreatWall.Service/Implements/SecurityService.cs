using System;
using System.Threading.Tasks;
using KissU.Modules.GreatWall.Application.Contracts.Abstractions;
using KissU.Modules.GreatWall.Application.Contracts.Dtos.Requests;
using KissU.Modules.GreatWall.Domain.Shared.Results;
using KissU.Modules.GreatWall.Service.Contracts;
using KissU.Surging.ProxyGenerator;

namespace KissU.Modules.GreatWall.Service.Implements
{
    /// <summary>
    /// 安全服务
    /// </summary>
    public class SecurityService : ProxyServiceBase, ISecurityService
    {
        private readonly ISecurityAppService _appService;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="appService">应用服务</param>
        /// <exception cref="ArgumentNullException">appService</exception>
        public SecurityService(ISecurityAppService appService)
        {
            _appService = appService ?? throw new ArgumentNullException(nameof(appService));
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="request">登录参数</param>
        /// <returns>Task&lt;SignInResult&gt;.</returns>
        public async Task<SignInResult> SignInAsync(LoginRequest request)
        {
            return await _appService.SignInAsync(request);
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        public async Task SignOutAsync()
        {
            await _appService.SignOutAsync();
        }
    }
}