using System.Threading;
using System.Threading.Tasks;
using KissU.Core.CPlatform.Filters.Implementation;

namespace KissU.Core.CPlatform.Filters
{
    /// <summary>
    /// 异常过滤器
    /// Implements the <see cref="T:KissU.Core.CPlatform.Filters.IFilter" />.
    /// </summary>
    /// <seealso cref="IFilter" />
    public interface IExceptionFilter : IFilter
    {
        /// <summary>
        /// 异步执行异常过滤器.
        /// </summary>
        /// <param name="actionExecutedContext">The action executed context.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task.</returns>
        Task ExecuteExceptionFilterAsync(RpcActionExecutedContext actionExecutedContext,
            CancellationToken cancellationToken);
    }
}