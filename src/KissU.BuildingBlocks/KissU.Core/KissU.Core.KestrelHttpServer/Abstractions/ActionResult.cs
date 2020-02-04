using System.Threading.Tasks;

namespace KissU.Core.KestrelHttpServer.Abstractions
{
    /// <summary>
    /// ActionResult.
    /// Implements the <see cref="KissU.Core.KestrelHttpServer.Abstractions.IActionResult" />
    /// </summary>
    /// <seealso cref="KissU.Core.KestrelHttpServer.Abstractions.IActionResult" />
    public abstract class ActionResult: IActionResult
    {
        /// <summary>
        /// Executes the result asynchronous.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>Task.</returns>
        public virtual Task ExecuteResultAsync(ActionContext context)
        {
            ExecuteResult(context);
            return Task.CompletedTask;
        }


        /// <summary>
        /// Executes the result.
        /// </summary>
        /// <param name="context">The context.</param>
        public virtual void ExecuteResult(ActionContext context)
        {
        }
    }
}
