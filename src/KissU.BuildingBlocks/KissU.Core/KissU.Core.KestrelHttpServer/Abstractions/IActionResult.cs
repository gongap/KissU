using System.Threading.Tasks;

namespace KissU.Core.KestrelHttpServer.Abstractions
{
    /// <summary>
    /// Interface IActionResult
    /// </summary>
    public interface IActionResult
    {
        /// <summary>
        /// Executes the result asynchronous.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>Task.</returns>
        Task ExecuteResultAsync(ActionContext context);
    }
}