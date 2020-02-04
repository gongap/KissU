using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KissU.Core.ProxyGenerator.Interceptors
{
    /// <summary>
    /// Interface IInvocation
    /// </summary>
    public interface IInvocation
    {
        /// <summary>
        /// Gets the proxy.
        /// </summary>
        object Proxy { get; }

        /// <summary>
        /// Gets the service identifier.
        /// </summary>
        string ServiceId { get; }

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        IDictionary<string, object> Arguments { get; }

        /// <summary>
        /// Gets the type of the return.
        /// </summary>
        Type ReturnType { get; }

        /// <summary>
        /// Gets or sets the return value.
        /// </summary>
        object ReturnValue { get; set; }

        /// <summary>
        /// Proceeds this instance.
        /// </summary>
        /// <returns>Task.</returns>
        Task Proceed();

        /// <summary>
        /// Sets the argument value.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="value">The value.</param>
        void SetArgumentValue(int index, object value);
    }
}