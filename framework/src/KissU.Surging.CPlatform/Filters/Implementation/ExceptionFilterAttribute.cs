using System;
using System.Threading;
using System.Threading.Tasks;
using KissU.Core.Helpers.Utilities;
using KissU.Surging.CPlatform.Utilities;

namespace KissU.Surging.CPlatform.Filters.Implementation
{
    /// <summary>
    /// 异常过滤器属性.
    /// Implements the <see cref="FilterAttribute" />
    /// Implements the <see cref="IExceptionFilter" />
    /// Implements the <see cref="IFilter" />
    /// </summary>
    /// <seealso cref="FilterAttribute" />
    /// <seealso cref="IExceptionFilter" />
    /// <seealso cref="IFilter" />
    public abstract class ExceptionFilterAttribute : FilterAttribute, IExceptionFilter, IFilter
    {
        /// <summary>
        /// 异步执行异常过滤器.
        /// </summary>
        /// <param name="actionExecutedContext">The action executed context.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task.</returns>
        Task IExceptionFilter.ExecuteExceptionFilterAsync(RpcActionExecutedContext actionExecutedContext,
            CancellationToken cancellationToken)
        {
            Check.NotNull(actionExecutedContext, "actionExecutedContext");
            return ExecuteExceptionFilterAsyncCore(actionExecutedContext, cancellationToken);
        }

        /// <summary>
        /// Called when [exception].
        /// </summary>
        /// <param name="actionExecutedContext">The action executed context.</param>
        public virtual void OnException(RpcActionExecutedContext actionExecutedContext)
        {
        }

        /// <summary>
        /// Called when [exception asynchronous].
        /// </summary>
        /// <param name="actionExecutedContext">The action executed context.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task.</returns>
        public virtual Task OnExceptionAsync(RpcActionExecutedContext actionExecutedContext,
            CancellationToken cancellationToken)
        {
            try
            {
                OnException(actionExecutedContext);
            }
            catch (Exception ex)
            {
                return TaskHelpers.FromError(ex);
            }

            return TaskHelpers.Completed();
        }

        private async Task ExecuteExceptionFilterAsyncCore(RpcActionExecutedContext actionExecutedContext,
            CancellationToken cancellationToken)
        {
            await OnExceptionAsync(actionExecutedContext, cancellationToken);
        }
    }
}