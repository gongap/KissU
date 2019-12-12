using System;
using System.Threading;
using System.Threading.Tasks;
using KissU.Core.CPlatform.Utilities;

namespace KissU.Core.CPlatform.Filters.Implementation
{
    public abstract class ExceptionFilterAttribute : FilterAttribute, IExceptionFilter, IFilter
    {
        public virtual void OnException(RpcActionExecutedContext actionExecutedContext)
        {

        }
        public virtual Task OnExceptionAsync(RpcActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
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

        Task IExceptionFilter.ExecuteExceptionFilterAsync(RpcActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            Check.NotNull(actionExecutedContext, "actionExecutedContext");
            return ExecuteExceptionFilterAsyncCore(actionExecutedContext, cancellationToken);
        }

        private async Task ExecuteExceptionFilterAsyncCore(RpcActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            await OnExceptionAsync(actionExecutedContext, cancellationToken);
        }
    }
}
