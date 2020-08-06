using System.Threading;
using KissU.CPlatform.Routing;

namespace KissU.CPlatform.Filters
{
    /// <summary>
    /// 授权过滤器
    /// Implements the <see cref="IFilter" />
    /// </summary>
    /// <seealso cref="IFilter" />
    public interface IAuthorizationFilter : IFilter
    {
        /// <summary>
        /// 异步执行授权过滤器.
        /// </summary>
        /// <param name="serviceRouteContext">The service route context.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        void ExecuteAuthorizationFilterAsync(ServiceRouteContext serviceRouteContext,
            CancellationToken cancellationToken);
    }
}