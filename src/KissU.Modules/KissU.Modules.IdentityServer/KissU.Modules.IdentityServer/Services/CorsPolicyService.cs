using System;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Services;
using KissU.Modules.IdentityServer.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace KissU.Modules.IdentityServer.Services
{
    /// <summary>
    /// 为客户端配置跨域访问
    /// </summary>
    public class CorsPolicyService : ICorsPolicyService
    {
        private readonly IHttpContextAccessor _context;
        private readonly ILogger<CorsPolicyService> _logger;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="context">上下文访问器</param>
        /// <param name="logger">日志记录器</param>
        public CorsPolicyService(IHttpContextAccessor context, ILogger<CorsPolicyService> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger;
        }

        /// <summary>
        ///是否允许跨域
        /// </summary>
        /// <param name="origin">跨域源</param>
        /// <returns></returns>
        public Task<bool> IsOriginAllowedAsync(string origin)
        {
            // 不在构造函数注入的原因: https://github.com/aspnet/CORS/issues/105
            var clientRepository = _context.HttpContext.RequestServices.GetRequiredService<IClientRepository>();

            var isAllowed = clientRepository.Exists(p => p.AllowedCorsOrigins.Any(x => x.Origin == origin));
            _logger.LogDebug("Origin {origin} is allowed: {originAllowed}", origin, isAllowed);

            return Task.FromResult(isAllowed);
        }
    }
}