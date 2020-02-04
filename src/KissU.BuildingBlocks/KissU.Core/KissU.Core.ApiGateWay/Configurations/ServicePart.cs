using System.Collections.Generic;

namespace KissU.Core.ApiGateWay.Configurations
{
    /// <summary>
    /// ServicePart.
    /// </summary>
    public class ServicePart
    {
        /// <summary>
        /// Gets or sets the main path.
        /// </summary>
        public string MainPath { get; set; } = "part/service/aggregation";

        /// <summary>
        /// Gets or sets a value indicating whether [enable authorization].
        /// </summary>
        public bool EnableAuthorization { get; set; }

        /// <summary>
        /// Gets or sets the services.
        /// </summary>
        public List<Services> Services { get; set; }
    }
}