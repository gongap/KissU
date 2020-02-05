using System.Security.Claims;
using System.Threading.Tasks;
using KissU.Util.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace KissU.Util.Security.Sessions
{
    /// <summary>
    /// 用户会话中间件
    /// </summary>
    public abstract class SessionMiddlewareBase
    {
        /// <summary>
        /// 方法
        /// </summary>
        private readonly RequestDelegate _next;

        /// <summary>
        /// 初始化用户会话中间件
        /// </summary>
        /// <param name="next">方法</param>
        protected SessionMiddlewareBase(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// 执行方法
        /// </summary>
        /// <param name="context">Http上下文</param>
        public async Task Invoke(HttpContext context)
        {
            await Authenticate(context);
            await _next(context);
        }

        /// <summary>
        /// 认证
        /// </summary>
        /// <param name="context">The context.</param>
        protected virtual async Task Authenticate(HttpContext context)
        {
            await AuthenticateBefore(context);
            if (IsAuthenticated(context) == false)
                return;
            await LoadClaims(context, context.GetIdentity());
            await AuthenticateAfter(context);
        }

        /// <summary>
        /// 认证前操作
        /// </summary>
        /// <param name="context">Http上下文</param>
        /// <returns>Task.</returns>
        protected virtual Task AuthenticateBefore(HttpContext context)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// 是否认证
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns><c>true</c> if the specified context is authenticated; otherwise, <c>false</c>.</returns>
        protected virtual bool IsAuthenticated(HttpContext context)
        {
            if (context.User == null)
                return false;
            if (context.User.Identity.IsAuthenticated == false)
                return false;
            return true;
        }

        /// <summary>
        /// 加载声明列表
        /// </summary>
        /// <param name="context">Http上下文</param>
        /// <param name="identity">身份标识</param>
        /// <returns>Task.</returns>
        protected abstract Task LoadClaims(HttpContext context, ClaimsIdentity identity);

        /// <summary>
        /// 认证后操作
        /// </summary>
        /// <param name="context">Http上下文</param>
        /// <returns>Task.</returns>
        protected virtual Task AuthenticateAfter(HttpContext context)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// 获取服务
        /// </summary>
        /// <typeparam name="T">服务类型</typeparam>
        /// <param name="context">Http上下文</param>
        /// <returns>T.</returns>
        protected T GetService<T>(HttpContext context)
        {
            return context.RequestServices.GetService<T>();
        }
    }
}