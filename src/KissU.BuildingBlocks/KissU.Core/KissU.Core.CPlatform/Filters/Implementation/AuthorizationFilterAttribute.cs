using System.Threading;
using KissU.Core.CPlatform.Routing;

namespace KissU.Core.CPlatform.Filters.Implementation
{
    /// <summary>
    /// 授权过滤器属性.
    /// Implements the <see cref="FilterAttribute" />
    /// Implements the <see cref="IAuthorizationFilter" />
    /// Implements the <see cref="IFilter" />
    /// </summary>
    /// <seealso cref="FilterAttribute" />
    /// <seealso cref="IAuthorizationFilter" />
    /// <seealso cref="IFilter" />
    public abstract class AuthorizationFilterAttribute : FilterAttribute, IAuthorizationFilter, IFilter
    {
        /// <summary>
        /// 异步执行授权过滤器.
        /// </summary>
        /// <param name="serviceRouteContext">The service route context.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public virtual void ExecuteAuthorizationFilterAsync(ServiceRouteContext serviceRouteContext,
            CancellationToken cancellationToken)
        {
            var result = OnAuthorization(serviceRouteContext);
            if (!result)
            {
                serviceRouteContext.ResultMessage.StatusCode = 401;
                serviceRouteContext.ResultMessage.ExceptionMessage = "令牌验证失败.";
            }
        }

        /// <summary>
        /// Called when [authorization].
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool OnAuthorization(ServiceRouteContext context)
        {
            return true;
        }
    }
}