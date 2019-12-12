using System.Threading;
using KissU.Core.CPlatform.Routing;

namespace KissU.Core.CPlatform.Filters
{
    public interface IAuthorizationFilter: IFilter
    {
        void ExecuteAuthorizationFilterAsync(ServiceRouteContext serviceRouteContext,CancellationToken cancellationToken);
    }
}
