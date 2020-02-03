using System.Collections.Generic;

namespace KissU.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes
{
    /// <summary>
    /// HttpPatchAttribute.
    /// Implements the <see cref="HttpMethodAttribute" />
    /// </summary>
    /// <seealso cref="HttpMethodAttribute" />
    public class HttpPatchAttribute : HttpMethodAttribute
    {
        private static readonly IEnumerable<string> _supportedMethods = new[] { "PATCH" };

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpPatchAttribute" /> class.
        /// </summary>
        public HttpPatchAttribute()
            : base(_supportedMethods)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpPatchAttribute" /> class.
        /// </summary>
        /// <param name="isRegisterMetadata">if set to <c>true</c> [is register metadata].</param>
        public HttpPatchAttribute(bool isRegisterMetadata)
            : base(_supportedMethods, isRegisterMetadata)
        {
        }
    }
}