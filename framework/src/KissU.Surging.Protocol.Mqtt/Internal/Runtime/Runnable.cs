using System;
using System.Threading;

namespace KissU.Surging.Protocol.Mqtt.Internal.Runtime
{
    /// <summary>
    /// Runnable.
    /// </summary>
    public abstract class Runnable
    {
        private readonly Timer _timer;
        private volatile Thread _runnableThread;

        /// <summary>
        /// Initializes a new instance of the <see cref="Runnable" /> class.
        /// </summary>
        public Runnable()
        {
            var timeSpan = TimeSpan.FromSeconds(3);
            _timer = new Timer(s => { Run(); }, null, timeSpan, timeSpan);
        }

        /// <summary>
        /// Runs this instance.
        /// </summary>
        public abstract void Run();
    }
}