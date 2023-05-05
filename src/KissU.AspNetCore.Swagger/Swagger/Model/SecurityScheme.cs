using System.Collections.Generic;
using Newtonsoft.Json;

namespace KissU.AspNetCore.Swagger.Swagger.Model
{
    /// <summary>
    /// SecurityScheme.
    /// </summary>
    public abstract class SecurityScheme
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityScheme" /> class.
        /// </summary>
        public SecurityScheme()
        {
            Extensions = new Dictionary<string, object>();
        }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets the extensions.
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, object> Extensions { get; }
    }
}