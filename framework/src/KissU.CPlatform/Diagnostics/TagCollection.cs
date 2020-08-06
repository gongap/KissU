using System.Collections;
using System.Collections.Generic;

namespace KissU.CPlatform.Diagnostics
{
    /// <summary>
    /// TagCollection.
    /// Implements the <see cref="IEnumerable{T}" />
    /// </summary>
    /// <seealso cref="IEnumerable{KeyValuePair{string, string}}" />
    public class TagCollection : IEnumerable<KeyValuePair<string, string>>
    {
        private readonly Dictionary<string, string> tags = new Dictionary<string, string>();

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return tags.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return tags.GetEnumerator();
        }

        /// <summary>
        /// Adds the tag.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        internal void AddTag(string key, string value)
        {
            tags[key] = value;
        }
    }
}