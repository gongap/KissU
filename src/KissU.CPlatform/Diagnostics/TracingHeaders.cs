using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace KissU.CPlatform.Diagnostics
{
    /// <summary>
    /// TracingHeaders.
    /// Implements the <see cref="IEnumerable{T}" />
    /// </summary>
    /// <seealso cref="IEnumerable{KeyValuePair{string, string}}" />
    public class TracingHeaders : IEnumerable<KeyValuePair<string, string>>
    {
        private readonly List<KeyValuePair<string, string>> _dataStore = new List<KeyValuePair<string, string>>();

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return _dataStore.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Adds the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        public void Add(string name, string value)
        {
            _dataStore.Add(new KeyValuePair<string, string>(name, value));
        }

        /// <summary>
        /// Determines whether this instance contains the object.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns><c>true</c> if [contains] [the specified name]; otherwise, <c>false</c>.</returns>
        public bool Contains(string name)
        {
            return _dataStore != null && _dataStore.Any(x => x.Key == name);
        }

        /// <summary>
        /// Removes the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        public void Remove(string name)
        {
            _dataStore?.RemoveAll(x => x.Key == name);
        }

        /// <summary>
        /// Cleaars this instance.
        /// </summary>
        public void Cleaar()
        {
            _dataStore?.Clear();
        }
    }
}