using System.Collections.Generic;

namespace KissU.Core.Caching.Models
{
    /// <summary>
    /// CachingProvider.
    /// </summary>
    public class CachingProvider
    {
        /// <summary>
        /// Gets or sets the caching settings.
        /// </summary>
        public List<Binding> CachingSettings { get; set; }
    }
}