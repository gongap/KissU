using System.Collections;
using System.Collections.Generic;

namespace KissU.Core.CPlatform.Diagnostics
{
    /// <summary>
    /// LogCollection.
    /// Implements the <see cref="IEnumerable{SpanLog}" />
    /// </summary>
    /// <seealso cref="IEnumerable{SpanLog}" />
    public class LogCollection : IEnumerable<SpanLog>
    {
        private readonly List<SpanLog> _logs = new List<SpanLog>();

        /// <summary>
        /// Adds the log.
        /// </summary>
        /// <param name="log">The log.</param>
        internal void AddLog(SpanLog log)
        {
            _logs.Add(log);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<SpanLog> GetEnumerator()
        {
            return _logs.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _logs.GetEnumerator();
        }
    }
}