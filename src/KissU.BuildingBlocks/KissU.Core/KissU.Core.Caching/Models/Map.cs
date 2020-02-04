using System.Collections.Generic;

namespace KissU.Core.Caching.Models
{
    /// <summary>
    /// Map.
    /// </summary>
    public class Map
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the properties.
        /// </summary>
        public List<Property> Properties { get; set; }
    }
}