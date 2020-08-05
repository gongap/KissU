using System.Threading.Tasks;

namespace KissU.Surging.Kestrel.Abstractions
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