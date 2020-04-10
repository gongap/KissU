using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Extensions.Primitives;

namespace KissU.Surging.KestrelHttpServer.Internal
{
    /// <summary>
    /// HttpFormCollection.
    /// Implements the
    /// <see
    ///     cref="System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{System.String, Microsoft.Extensions.Primitives.StringValues}}" />
    /// Implements the <see cref="System.Collections.IEnumerable" />
    /// </summary>
    /// <seealso
    ///     cref="System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{System.String, Microsoft.Extensions.Primitives.StringValues}}" />
    /// <seealso cref="System.Collections.IEnumerable" />
    public class HttpFormCollection : IEnumerable<KeyValuePair<string, StringValues>>, IEnumerable
    {
        /// <summary>
        /// The empty
        /// </summary>
        public static readonly HttpFormCollection Empty = new HttpFormCollection();

        private static readonly string[] EmptyKeys = Array.Empty<string>();
        private static readonly StringValues[] EmptyValues = Array.Empty<StringValues>();
        private static readonly Enumerator EmptyEnumerator = new Enumerator();
        private static readonly IEnumerator<KeyValuePair<string, StringValues>> EmptyIEnumeratorType = EmptyEnumerator;
        private static readonly IEnumerator EmptyIEnumerator = EmptyEnumerator;

        private static readonly HttpFormFileCollection EmptyFiles = new HttpFormFileCollection();

        private HttpFormFileCollection _files;

        private HttpFormCollection()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpFormCollection" /> class.
        /// </summary>
        /// <param name="fields">The fields.</param>
        /// <param name="files">The files.</param>
        public HttpFormCollection(Dictionary<string, StringValues> fields, HttpFormFileCollection files = null)
        {
            Store = fields;
            _files = files;
        }

        /// <summary>
        /// Gets the files.
        /// </summary>
        public HttpFormFileCollection Files
        {
            get => _files ?? EmptyFiles;
            private set => _files = value;
        }

        private Dictionary<string, StringValues> Store { get; }


        /// <summary>
        /// Gets the <see cref="StringValues" /> with the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>StringValues.</returns>
        public StringValues this[string key]
        {
            get
            {
                if (Store == null)
                {
                    return StringValues.Empty;
                }

                StringValues value;
                if (TryGetValue(key, out value))
                {
                    return value;
                }

                return StringValues.Empty;
            }
        }


        /// <summary>
        /// Gets the count.
        /// </summary>
        public int Count => Store?.Count ?? 0;

        /// <summary>
        /// Gets the keys.
        /// </summary>
        public ICollection<string> Keys
        {
            get
            {
                if (Store == null)
                {
                    return EmptyKeys;
                }

                return Store.Keys;
            }
        }

        IEnumerator<KeyValuePair<string, StringValues>> IEnumerable<KeyValuePair<string, StringValues>>.GetEnumerator()
        {
            if (Store == null || Store.Count == 0)
            {
                return EmptyIEnumeratorType;
            }

            return Store.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            if (Store == null || Store.Count == 0)
            {
                return EmptyIEnumerator;
            }

            return Store.GetEnumerator();
        }


        /// <summary>
        /// Determines whether the specified key contains key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns><c>true</c> if the specified key contains key; otherwise, <c>false</c>.</returns>
        public bool ContainsKey(string key)
        {
            if (Store == null)
            {
                return false;
            }

            return Store.ContainsKey(key);
        }

        /// <summary>
        /// Tries the get value.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool TryGetValue(string key, out StringValues value)
        {
            if (Store == null)
            {
                value = default;
                return false;
            }

            return Store.TryGetValue(key, out value);
        }

        /// <summary>
        /// Gets the enumerator.
        /// </summary>
        /// <returns>Enumerator.</returns>
        public Enumerator GetEnumerator()
        {
            if (Store == null || Store.Count == 0)
            {
                return EmptyEnumerator;
            }

            return new Enumerator(Store.GetEnumerator());
        }
    }

    /// <summary>
    /// Struct Enumerator
    /// Implements the
    /// <see
    ///     cref="System.Collections.Generic.IEnumerator{System.Collections.Generic.KeyValuePair{System.String, Microsoft.Extensions.Primitives.StringValues}}" />
    /// </summary>
    /// <seealso
    ///     cref="System.Collections.Generic.IEnumerator{System.Collections.Generic.KeyValuePair{System.String, Microsoft.Extensions.Primitives.StringValues}}" />
    public struct Enumerator : IEnumerator<KeyValuePair<string, StringValues>>
    {
        private Dictionary<string, StringValues>.Enumerator _dictionaryEnumerator;
        private readonly bool _notEmpty;

        /// <summary>
        /// Initializes a new instance of the <see cref="Enumerator" /> struct.
        /// </summary>
        /// <param name="dictionaryEnumerator">The dictionary enumerator.</param>
        internal Enumerator(Dictionary<string, StringValues>.Enumerator dictionaryEnumerator)
        {
            _dictionaryEnumerator = dictionaryEnumerator;
            _notEmpty = true;
        }

        /// <summary>
        /// Advances the enumerator to the next element of the collection.
        /// </summary>
        /// <returns>
        /// <see langword="true" /> if the enumerator was successfully advanced to the next element;
        /// <see langword="false" /> if the enumerator has passed the end of the collection.
        /// </returns>
        public bool MoveNext()
        {
            if (_notEmpty)
            {
                return _dictionaryEnumerator.MoveNext();
            }

            return false;
        }

        /// <summary>
        /// Gets the current.
        /// </summary>
        public KeyValuePair<string, StringValues> Current
        {
            get
            {
                if (_notEmpty)
                {
                    return _dictionaryEnumerator.Current;
                }

                return default;
            }
        }

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public void Dispose()
        {
        }

        object IEnumerator.Current => Current;

        void IEnumerator.Reset()
        {
            if (_notEmpty)
            {
                ((IEnumerator) _dictionaryEnumerator).Reset();
            }
        }
    }
}