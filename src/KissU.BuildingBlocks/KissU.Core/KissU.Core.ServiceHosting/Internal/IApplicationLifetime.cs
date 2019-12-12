using System.Threading;

namespace KissU.Core.ServiceHosting.Internal
{
   public  interface IApplicationLifetime
    {
        CancellationToken ApplicationStarted { get; }
 
        CancellationToken ApplicationStopping { get; }
         
        CancellationToken ApplicationStopped { get; }

 
        void StopApplication();

        void NotifyStopped();

        void NotifyStarted();
    }
}
