using System.Threading.Tasks;
using KissU.Surging.KestrelHttpServer.Filters.Implementation;

namespace KissU.Surging.KestrelHttpServer.Filters
{
    /// <summary>
    /// Interface IAuthorizationFilter
    /// Implements the <see cref="KissU.Surging.KestrelHttpServer.Filters.IFilter" />
    /// </summary>
    /// <seealso cref="KissU.Surging.KestrelHttpServer.Filters.IFilter" />
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