using System;

namespace KissU.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes
{
    /// <summary>
    /// ServiceRouteAttribute.
    /// Implements the <see cref="Attribute" />
    /// </summary>
    /// <seealso cref="Attribute" />
    public class ServiceRouteAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceRouteAttribute" /> class.
        /// </summary>
        /// <param name="template">The template.</param>
        public ServiceRouteAttribute(string template)
        {
            Template = template;
        }

        /// <summary>
        /// Gets the template.
        /// </summary>
        public string Template { get; }
    }
}