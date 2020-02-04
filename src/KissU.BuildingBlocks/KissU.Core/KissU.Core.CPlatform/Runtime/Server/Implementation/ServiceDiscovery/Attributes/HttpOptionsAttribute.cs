using System.Collections.Generic;

namespace KissU.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes
{
    /// <summary>
    /// HttpOptionsAttribute.
    /// Implements the <see cref="HttpMethodAttribute" />
    /// </summary>
    /// <seealso cref="HttpMethodAttribute" />
    public class HttpOptionsAttribute : HttpMethodAttribute
    {
        private static readonly IEnumerable<string> _supportedMethods = new[] {"OPTIONS"};

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpOptionsAttribute" /> class.
        /// </summary>
        public HttpOptionsAttribute()
            : base(_supportedMethods)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpOptionsAttribute" /> class.
        /// </summary>
        /// <param name="isRegisterMetadata">if set to <c>true</c> [is register metadata].</param>
        public HttpOptionsAttribute(bool isRegisterMetadata)
            : base(_supportedMethods, isRegisterMetadata)
        {
        }
    }
}