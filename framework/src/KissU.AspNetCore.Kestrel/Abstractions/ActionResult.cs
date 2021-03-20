using System.Threading.Tasks;
using KissU.AspNetCore.Abstractions;

namespace KissU.AspNetCore.Kestrel.Abstractions
{
    /// <summary>
    /// ActionResult.
    /// Implements the <see cref="IActionResult" />
    /// </summary>
    /// <seealso cref="IActionResult" />
    public abstract class ActionResult : IActionResult
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