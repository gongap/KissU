using System.Threading;
using System.Threading.Tasks;

namespace KissU.Core.ServiceHosting.Internal
{
   public interface IHostLifetime
    {
         
        Task WaitForStartAsync(CancellationToken cancellationToken);
 
        Task StopAsync(CancellationToken cancellationToken);
    }
}
