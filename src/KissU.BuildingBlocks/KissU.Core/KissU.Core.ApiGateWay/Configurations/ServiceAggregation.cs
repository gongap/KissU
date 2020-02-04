using System.Collections.Generic;

namespace KissU.Core.ApiGateWay.Configurations
{
    /// <summary>
    /// ServiceAggregation.
    /// </summary>
    public class ServiceAggregation
    {
        /// <summary>
        /// Gets or sets the route path.
        /// </summary>
        public string RoutePath { get; set; }

        /// <summary>
        /// Gets or sets the service key.
        /// </summary>
        public string ServiceKey { get; set; }

        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        public Dictionary<string, object> Params { get; set; }

        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        public string Key { get; set; }
    }
}