using System;

namespace KissU.Core.Stage.Configurations
{
    /// <summary>
    /// DataRateOption.
    /// </summary>
    public class DataRateOption
    {
        /// <summary>
        /// Gets or sets the bytes per second.
        /// </summary>
        public double BytesPerSecond { get; set; }
        /// <summary>
        /// Gets or sets the grace period.
        /// </summary>
        public TimeSpan GracePeriod { get; set; }
    }
}
