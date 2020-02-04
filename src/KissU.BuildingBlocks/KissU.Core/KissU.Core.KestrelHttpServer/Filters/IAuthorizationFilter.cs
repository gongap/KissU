using System.Threading.Tasks;
using KissU.Core.KestrelHttpServer.Filters.Implementation;

namespace KissU.Core.KestrelHttpServer.Filters
{
    /// <summary>
    /// Interface IAuthorizationFilter
    /// Implements the <see cref="KissU.Core.KestrelHttpServer.Filters.IFilter" />
    /// </summary>
    /// <seealso cref="KissU.Core.KestrelHttpServer.Filters.IFilter" />
    public interface IAuthorizationFilter : IFilter
    {
        /// <summary>
        /// Called when [authorization].
        /// </summary>
        /// <param name="serviceRouteContext">The service route context.</param>
        /// <returns>Task.</returns>
        Task OnAuthorization(AuthorizationFilterContext serviceRouteContext);
    }
}