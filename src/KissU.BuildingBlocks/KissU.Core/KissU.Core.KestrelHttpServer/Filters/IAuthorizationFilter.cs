using System.Threading.Tasks;
using KissU.Core.KestrelHttpServer.Filters.Implementation;

namespace KissU.Core.KestrelHttpServer.Filters
{
    public interface IAuthorizationFilter : IFilter
    {
        Task OnAuthorization(AuthorizationFilterContext serviceRouteContext);
    }
}
