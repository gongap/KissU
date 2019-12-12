using System.Threading;
using System.Threading.Tasks;
using KissU.Core.CPlatform.Filters.Implementation;

namespace KissU.Core.CPlatform.Filters
{
   public interface IExceptionFilter: IFilter
    {
        Task ExecuteExceptionFilterAsync(RpcActionExecutedContext actionExecutedContext, CancellationToken cancellationToken);
    }
}
