using System.Threading.Tasks;
using KissU.Core.CPlatform.Messages;

namespace KissU.Core.KestrelHttpServer.Filters.Implementation
{
    /// <summary>
    /// CustomerExceptionFilterAttribute.
    /// Implements the <see cref="KissU.Core.KestrelHttpServer.Filters.IExceptionFilter" />
    /// </summary>
    /// <seealso cref="KissU.Core.KestrelHttpServer.Filters.IExceptionFilter" />
    public class CustomerExceptionFilterAttribute : IExceptionFilter
    {
        /// <summary>
        /// Called when [exception].
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>Task.</returns>
        public Task OnException(ExceptionContext context)
        {
            context.Result = new HttpResultMessage<object>
            {
                Data = null,
                StatusCode = 400,
                IsSucceed = false,
                Message = context.Exception.Message
            };
            return Task.CompletedTask;
        }
    }
}
