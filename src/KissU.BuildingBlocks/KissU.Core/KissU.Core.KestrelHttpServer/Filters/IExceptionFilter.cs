using System.Threading.Tasks;
using KissU.Core.KestrelHttpServer.Filters.Implementation;

namespace KissU.Core.KestrelHttpServer.Filters
{
   public interface IExceptionFilter
    { 
          Task OnException(ExceptionContext context);
    }
}
