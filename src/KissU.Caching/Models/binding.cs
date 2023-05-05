using System.Collections.Generic;

namespace KissU.Caching.Models
{
    /// <summary>
    /// Binding.
    /// </summary>
    public class Binding
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the class.
        /// </summary>
        public string Class { get; set; }

        /// <summary>
        /// Gets or sets the initialize method.
        /// </summary>
        public string InitMethod { get; set; }

        /// <summary>
        /// Gets or sets the maps.
        /// </summary>
        public List<Map> Maps { get; set; }

        /// <summary>
        /// Gets or sets the properties.
        /// </summary>
        public List<Property> Properties { get; set; }
    }
}