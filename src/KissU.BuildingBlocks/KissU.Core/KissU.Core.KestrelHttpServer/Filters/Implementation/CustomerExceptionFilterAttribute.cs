using System.Threading.Tasks;
using KissU.Core.CPlatform.Messages;

namespace KissU.Core.KestrelHttpServer.Filters.Implementation
{
   public class CustomerExceptionFilterAttribute : IExceptionFilter
    {
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
