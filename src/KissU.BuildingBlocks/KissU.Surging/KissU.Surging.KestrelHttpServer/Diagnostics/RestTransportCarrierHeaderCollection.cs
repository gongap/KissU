using System.Collections;
using System.Collections.Generic;
using KissU.Surging.CPlatform.Diagnostics;

namespace KissU.Surging.KestrelHttpServer.Diagnostics
{
    /// <summary>
    /// RestTransportCarrierHeaderCollection.
    /// Implements the <see cref="KissU.Surging.CPlatform.Diagnostics.ICarrierHeaderCollection" />
    /// </summary>
    /// <seealso cref="KissU.Surging.CPlatform.Diagnostics.ICarrierHeaderCollection" />
    public class RestTransportCarrierHeaderCollection : ICarrierHeaderCollection
    {
        private readonly TracingHeaders _tracingHeaders;

        /// <summary>
        /// Initializes a new instance of the <see cref="RestTransportCarrierHeaderCollection" /> class.
        /// </summary>
        /// <param name="tracingHeaders">The tracing headers.</param>
        public RestTransportCarrierHeaderCollection(TracingHeaders tracingHeaders)
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