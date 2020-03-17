using System.Collections.Generic;

namespace KissU.Surging.Caching.Models
{
    /// <summary>
    /// Property.
    /// </summary>
    public class Property
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the reference.
        /// </summary>
        public string Ref { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the maps.
        /// </summary>
        public List<Map> Maps { get; set; }
    }
}