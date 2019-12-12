using System.Threading.Tasks;
using KissU.Core.KestrelHttpServer.Filters.Implementation;

namespace KissU.Core.KestrelHttpServer.Filters
{
   public interface IActionFilter
    {
        Task OnActionExecuting(ActionExecutingContext filterContext);

        Task OnActionExecuted(ActionExecutedContext filterContext);
    }
}
