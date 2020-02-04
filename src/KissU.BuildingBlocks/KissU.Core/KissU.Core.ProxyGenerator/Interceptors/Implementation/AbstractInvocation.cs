using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KissU.Core.ProxyGenerator.Interceptors.Implementation
{
    /// <summary>
    /// AbstractInvocation.
    /// Implements the <see cref="KissU.Core.ProxyGenerator.Interceptors.IInvocation" />
    /// Implements the <see cref="KissU.Core.ProxyGenerator.Interceptors.ICacheInvocation" />
    /// </summary>
    /// <seealso cref="KissU.Core.ProxyGenerator.Interceptors.IInvocation" />
    /// <seealso cref="KissU.Core.ProxyGenerator.Interceptors.ICacheInvocation" />
    public abstract class AbstractInvocation : IInvocation, ICacheInvocation
    {
        /// <summary>
        /// The proxy object
        /// </summary>
        protected readonly object proxyObject;

        /// <summary>
        /// The return value
        /// </summary>
        protected object _returnValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractInvocation" /> class.
        /// </summary>
        /// <param name="arguments">The arguments.</param>
        /// <param name="serviceId">The service identifier.</param>
        /// <param name="cacheKey">The cache key.</param>
        /// <param name="attributes">The attributes.</param>
        /// <param name="returnType">Type of the return.</param>
        /// <param name="proxy">The proxy.</param>
        protected AbstractInvocation(
            IDictionary<string, object> arguments,
            string serviceId,
            string[] cacheKey,
            List<Attribute> attributes,
            Type returnType,
            object proxy
        )
        {
            Arguments = arguments;
            ServiceId = serviceId;
            CacheKey = cacheKey;
            Attributes = attributes;
            ReturnType = returnType;
            proxyObject = proxy;
        }

        /// <summary>
        /// Gets the cache key.
        /// </summary>
        public string[] CacheKey { get; }

        /// <summary>
        /// Gets the attributes.
        /// </summary>
        public List<Attribute> Attributes { get; }

        /// <summary>
        /// Gets the proxy.
        /// </summary>
        public object Proxy => proxyObject;

        /// <summary>
        /// Gets the service identifier.
        /// </summary>
        public string ServiceId { get; }

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        public IDictionary<string, object> Arguments { get; }

        object IInvocation.ReturnValue
        {
            get => _returnValue;
            set => _returnValue = value;
        }

        /// <summary>
        /// Gets the type of the return.
        /// </summary>
        public Type ReturnType { get; }

        /// <summary>
        /// Proceeds this instance.
        /// </summary>
        /// <returns>Task.</returns>
        public abstract Task Proceed();


        /// <summary>
        /// Sets the argument value.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="value">The value.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void SetArgumentValue(int index, object value)
        {
            throw new NotImplementedException();
        }
    }
}