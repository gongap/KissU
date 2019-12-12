using System.Threading.Tasks;

namespace KissU.Core.KestrelHttpServer.Abstractions
{
   public interface IActionResult
    {
        Task ExecuteResultAsync(ActionContext context);
    }
}
