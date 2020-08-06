using System.Collections;
using System.Collections.Generic;
using KissU.CPlatform.Diagnostics;

namespace KissU.ProxyGenerator.Diagnostics
{
    /// <summary>
    /// RpcTransportCarrierHeaderCollection.
    /// Implements the <see cref="KissU.CPlatform.Diagnostics.ICarrierHeaderCollection" />
    /// </summary>
    /// <seealso cref="KissU.CPlatform.Diagnostics.ICarrierHeaderCollection" />
    public class RpcTransportCarrierHeaderCollection : ICarrierHeaderCollection
    {
        private readonly TracingHeaders _tracingHeaders;

        /// <summary>
        /// Initializes a new instance of the <see cref="RpcTransportCarrierHeaderCollection" /> class.
        /// </summary>
        /// <param name="tracingHeaders">The tracing headers.</param>
        public RpcTransportCarrierHeaderCollection(TracingHeaders tracingHeaders)
        {
            _tracingHeaders = tracingHeaders;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return _tracingHeaders.GetEnumerator();
        }

        /// <summary>
        /// Adds the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void Add(string key, string value)
        {
            _tracingHeaders.Add(key, value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _tracingHeaders.GetEnumerator();
        }
    }
}