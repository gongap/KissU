using System.Threading.Tasks;
using KissU.Core.KestrelHttpServer.Filters.Implementation;

namespace KissU.Core.KestrelHttpServer.Filters
{
    /// <summary>
    /// Interface IActionFilter
    /// </summary>
    public interface IActionFilter
    {
        /// <summary>
        /// Called when [action executing].
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        /// <returns>Task.</returns>
        Task OnActionExecuting(ActionExecutingContext filterContext);

        /// <summary>
        /// Called when [action executed].
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        /// <returns>Task.</returns>
        Task OnActionExecuted(ActionExecutedContext filterContext);
    }
}