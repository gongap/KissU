﻿using System.Collections.Generic;

namespace KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes
{
    /// <summary>
    /// HttpGetAttribute.
    /// Implements the <see cref="HttpMethodAttribute" />
    /// </summary>
    /// <seealso cref="HttpMethodAttribute" />
    public class HttpGetAttribute : HttpMethodAttribute
    {
        private static readonly IEnumerable<string> _supportedMethods = new[] {"GET"};

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpGetAttribute" /> class.
        /// </summary>
        public HttpGetAttribute()
            : base(_supportedMethods)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpGetAttribute" /> class.
        /// </summary>
        /// <param name="isRegisterMetadata">if set to <c>true</c> [is register metadata].</param>
        public HttpGetAttribute(bool isRegisterMetadata)
            : base(_supportedMethods, isRegisterMetadata)
        {
        }
    }
}