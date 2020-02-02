using System.Collections.Generic;

namespace KissU.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes
{
    /// <summary>
    /// HttpPostAttribute.
    /// Implements the <see cref="HttpMethodAttribute" />
    /// </summary>
    /// <seealso cref="HttpMethodAttribute" />
    public class HttpPostAttribute : HttpMethodAttribute
    {
        private static readonly IEnumerable<string> _supportedMethods = new[] { "POST" };

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpPostAttribute"/> class.
        /// </summary>
        public HttpPostAttribute()
            : base(_supportedMethods)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpPostAttribute"/> class.
        /// </summary>
        /// <param name="isRegisterMetadata">if set to <c>true</c> [is register metadata].</param>
        public HttpPostAttribute(bool isRegisterMetadata)
            : base(_supportedMethods, isRegisterMetadata)
        {
        }
    }
}