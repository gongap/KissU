using System;
using System.Collections.Generic;

namespace KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes
{
    /// <summary>
    /// HttpMethodAttribute.
    /// Implements the <see cref="Attribute" />
    /// </summary>
    /// <seealso cref="Attribute" />
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public abstract class HttpMethodAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpMethodAttribute" /> class.
        /// </summary>
        /// <param name="httpMethods">The HTTP methods.</param>
        public HttpMethodAttribute(IEnumerable<string> httpMethods)
            : this(httpMethods, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpMethodAttribute" /> class.
        /// </summary>
        /// <param name="httpMethods">The HTTP methods.</param>
        /// <param name="isRegisterMetadata">if set to <c>true</c> [is register metadata].</param>
        /// <exception cref="ArgumentNullException">httpMethods</exception>
        public HttpMethodAttribute(IEnumerable<string> httpMethods, bool isRegisterMetadata)
        {
            if (httpMethods == null)
            {
                throw new ArgumentNullException(nameof(httpMethods));
            }

            HttpMethods = httpMethods;
            IsRegisterMetadata = isRegisterMetadata;
        }

        /// <summary>
        /// Gets the HTTP methods.
        /// </summary>
        public IEnumerable<string> HttpMethods { get; }

        /// <summary>
        /// Gets a value indicating whether this instance is register metadata.
        /// </summary>
        public bool IsRegisterMetadata { get; }
    }
}