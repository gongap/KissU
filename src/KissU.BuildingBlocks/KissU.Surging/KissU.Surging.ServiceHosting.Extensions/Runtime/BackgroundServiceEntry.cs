using System;

namespace KissU.Surging.ServiceHosting.Extensions.Runtime
{
    /// <summary>
    /// BackgroundServiceEntry.
    /// </summary>
    public class BackgroundServiceEntry
    {
        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public Type Type { get; set; }

        /// <summary>
        /// Gets or sets the behavior.
        /// </summary>
        public BackgroundServiceBehavior Behavior { get; set; }
    }
}