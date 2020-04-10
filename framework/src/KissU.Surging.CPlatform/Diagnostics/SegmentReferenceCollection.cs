using System.Collections;
using System.Collections.Generic;

namespace KissU.Surging.CPlatform.Diagnostics
{
    /// <summary>
    /// SegmentReferenceCollection.
    /// Implements the <see cref="IEnumerable{T}" />
    /// </summary>
    /// <seealso cref="IEnumerable{SegmentReference}" />
    public class SegmentReferenceCollection : IEnumerable<SegmentReference>
    {
        private readonly HashSet<SegmentReference> _references = new HashSet<SegmentReference>();

        /// <summary>
        /// Gets the count.
        /// </summary>
        public int Count => _references.Count;

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<SegmentReference> GetEnumerator()
        {
            return _references.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _references.GetEnumerator();
        }

        /// <summary>
        /// Adds the specified reference.
        /// </summary>
        /// <param name="reference">The reference.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Add(SegmentReference reference)
        {
            return _references.Add(reference);
        }
    }
}