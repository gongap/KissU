using System.Threading.Tasks;
using KissU.AspNetCore.Filters;
using KissU.CPlatform.Messages;
using KissU.Exceptions;

namespace KissU.AspNetCore.Kestrel.Filters.Implementation
{
    /// <summary>
    /// CustomerExceptionFilterAttribute.
    /// Implements the <see cref="IExceptionFilter" />
    /// </summary>
    /// <seealso cref="IExceptionFilter" />
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
                Result = null,
                StatusCode = 400,
                IsSucceed = false,
                Message = context.Exception.Message,
            };

            if (context.Exception is CPlatformCommunicationException  communicationException)
            {
                context.Result.Details = communicationException.Details;
                context.Result.ValidationErrors = communicationException.ValidationErrors;
            }

            return Task.CompletedTask;
        }
    }
}