using System.Collections.Generic;

namespace KissU.Services.SampleA.Contract.Dtos
{
    /// <summary>
    /// Message.
    /// </summary>
    public class Message
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
        public IDictionary<string, object> Parameters { get; set; }
    }
}