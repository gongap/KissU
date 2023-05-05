using System.Threading.Tasks;

namespace KissU.AspNetCore.Filters
{
    /// <summary>
    /// Interface IAuthorizationFilter
    /// Implements the <see cref="IFilter" />
    /// </summary>
    /// <seealso cref="IFilter" />
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