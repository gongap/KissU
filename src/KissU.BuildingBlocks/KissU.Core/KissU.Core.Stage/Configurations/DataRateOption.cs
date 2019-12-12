using System;

namespace KissU.Core.Stage.Configurations
{
    public class DataRateOption
    { 
        public double BytesPerSecond { get; set; } 
        public TimeSpan GracePeriod { get; set; }
    }
}
