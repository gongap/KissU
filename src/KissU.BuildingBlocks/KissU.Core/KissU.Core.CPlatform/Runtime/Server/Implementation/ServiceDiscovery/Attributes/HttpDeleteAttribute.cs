using System.Collections.Generic;

namespace KissU.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes
{
    /// <summary>
    /// HttpDeleteAttribute.
    /// Implements the <see cref="HttpMethodAttribute" />
    /// </summary>
    /// <seealso cref="HttpMethodAttribute" />
    public class HttpDeleteAttribute : HttpMethodAttribute
    {
        private static readonly IEnumerable<string> _supportedMethods = new[] { "DELETE" };

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpDeleteAttribute" /> class.
        /// </summary>
        public HttpDeleteAttribute()
            : base(_supportedMethods)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpDeleteAttribute" /> class.
        /// </summary>
        /// <param name="isRegisterMetadata">if set to <c>true</c> [is register metadata].</param>
        public HttpDeleteAttribute(bool isRegisterMetadata)
            : base(_supportedMethods, isRegisterMetadata)
        {
        }
    }
}