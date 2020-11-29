using System.Threading.Tasks;

namespace KissU.AspNetCore.Filters
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