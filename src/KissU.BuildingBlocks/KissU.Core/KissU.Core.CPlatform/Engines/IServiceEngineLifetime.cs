using System.Threading;

namespace KissU.Core.CPlatform.Engines
{
   public interface IServiceEngineLifetime
    {
        CancellationToken ServiceEngineStarted { get; }

        CancellationToken ServiceEngineStopping { get; }

        CancellationToken ServiceEngineStopped { get; }


        void StopApplication();

        void NotifyStopped();

        void NotifyStarted();
    }
}
