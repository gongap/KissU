using System.Collections;
using System.Collections.Generic;
using KissU.CPlatform.Diagnostics;
using SkyApm.Tracing;

namespace KissU.DotNetty.Mqtt.Diagnostics
{
    /// <summary>
    /// MqttTransportCarrierHeaderCollection.
    /// Implements the <see cref="ICarrierHeaderCollection" />
    /// </summary>
    /// <seealso cref="ICarrierHeaderCollection" />
    public class MqttTransportCarrierHeaderCollection : ICarrierHeaderCollection
    {
        private readonly TracingHeaders _tracingHeaders;

        public TracingHeaders TracingHeaders => _tracingHeaders;

        /// <summary>
        /// Initializes a new instance of the <see cref="MqttTransportCarrierHeaderCollection" /> class.
        /// </summary>
        /// <param name="tracingHeaders">The tracing headers.</param>
        public MqttTransportCarrierHeaderCollection(TracingHeaders tracingHeaders)
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