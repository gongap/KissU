using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.ServiceProxy.Implementation;

namespace KissU.ServiceProxy.Interceptors.Implementation
{
    /// <summary>
    /// ActionInvocation.
    /// Implements the <see cref="AbstractInvocation" />
    /// </summary>
    /// <seealso cref="AbstractInvocation" />
    public class ActionInvocation : AbstractInvocation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActionInvocation" /> class.
        /// </summary>
        /// <param name="arguments">The arguments.</param>
        /// <param name="serviceId">The service identifier.</param>
        /// <param name="cacheKey">The cache key.</param>
        /// <param name="attributes">The attributes.</param>
        /// <param name="returnType">Type of the return.</param>
        /// <param name="proxy">The proxy.</param>
        protected ActionInvocation(
            IDictionary<string, object> arguments,
            string serviceId,
            string[] cacheKey,
            List<Attribute> attributes,
            Type returnType,
            object proxy
        ) : base(arguments, serviceId, cacheKey, attributes, returnType, proxy)
        {
        }

        /// <summary>
        /// Proceeds this instance.
        /// </summary>
        public override async Task Proceed()
        {
            try
            {
                if (_returnValue == null)
                    _returnValue = await (Proxy as ServiceProxyBase).CallInvoke(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}