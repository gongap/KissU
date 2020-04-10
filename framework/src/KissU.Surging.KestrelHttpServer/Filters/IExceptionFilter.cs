using System.Threading.Tasks;
using KissU.Surging.KestrelHttpServer.Filters.Implementation;

namespace KissU.Surging.KestrelHttpServer.Filters
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