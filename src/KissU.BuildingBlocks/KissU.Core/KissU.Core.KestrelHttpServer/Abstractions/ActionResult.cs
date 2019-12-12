using System.Threading.Tasks;

namespace KissU.Core.KestrelHttpServer.Abstractions
{
    public abstract class ActionResult: IActionResult
    {
        public virtual Task ExecuteResultAsync(ActionContext context)
        {
            ExecuteResult(context);
            return Task.CompletedTask;
        }

        
        public virtual void ExecuteResult(ActionContext context)
        {
        }
    }
}
