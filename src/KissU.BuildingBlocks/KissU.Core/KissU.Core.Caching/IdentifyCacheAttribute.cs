using System;

namespace KissU.Core.Caching
{
    /// <summary>
    /// IdentifyCacheAttribute.
    /// Implements the <see cref="System.Attribute" />
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
    public class IdentifyCacheAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IdentifyCacheAttribute" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public IdentifyCacheAttribute(CacheTargetType name)
        {
            Name = name;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public CacheTargetType Name { get; set; }
    }
}