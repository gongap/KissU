using System.Threading.Tasks;
using KissU.Core.KestrelHttpServer.Filters.Implementation;

namespace KissU.Core.KestrelHttpServer.Filters
{
    /// <summary>
    /// Interface IExceptionFilter
    /// </summary>
    public interface IExceptionFilter
    {
        /// <summary>
        /// Called when [exception].
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>Task.</returns>
        Task OnException(ExceptionContext context);
    }
}