using System.Threading.Tasks;
using KissU.Surging.CPlatform.Messages;

namespace KissU.Surging.KestrelHttpServer.Filters.Implementation
{
    /// <summary>
    /// CustomerExceptionFilterAttribute.
    /// Implements the <see cref="KissU.Surging.KestrelHttpServer.Filters.IExceptionFilter" />
    /// </summary>
    /// <seealso cref="KissU.Surging.KestrelHttpServer.Filters.IExceptionFilter" />
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