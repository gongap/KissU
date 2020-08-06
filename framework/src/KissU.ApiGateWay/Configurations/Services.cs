using System.Collections.Generic;

namespace KissU.ApiGateWay.Configurations
{
    /// <summary>
    /// Services.
    /// </summary>
    public class Services
    {
        /// <summary>
        /// Gets or sets the service aggregation.
        /// </summary>
        public List<ServiceAggregation> serviceAggregation { get; set; }

        /// <summary>
        /// Gets or sets the URL mapping.
        /// </summary>
        public string UrlMapping { get; set; }
    }
}