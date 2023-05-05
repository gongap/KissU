using System;
using System.Collections.Generic;

namespace KissU.AspNetCore.Kestrel.Internal
{
    /// <summary>
    /// HttpFormFileCollection.
    /// Implements the <see cref="HttpFormFile" />
    /// </summary>
    /// <seealso cref="HttpFormFile" />
    public class HttpFormFileCollection : List<HttpFormFile>
    {
        /// <summary>
        /// Gets the <see cref="HttpFormFile" /> with the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>HttpFormFile.</returns>
        public HttpFormFile this[string name] => GetFile(name);

        /// <summary>
        /// Gets the file.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>HttpFormFile.</returns>
        public HttpFormFile GetFile(string name)
        {
            foreach (var file in this)
            {
                if (string.Equals(name, file.Name, StringComparison.OrdinalIgnoreCase))
                {
                    return file;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the files.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>IReadOnlyList&lt;HttpFormFile&gt;.</returns>
        public IReadOnlyList<HttpFormFile> GetFiles(string name)
        {
            var files = new List<HttpFormFile>();

            foreach (var file in this)
            {
                if (string.Equals(name, file.Name, StringComparison.OrdinalIgnoreCase))
                {
                    files.Add(file);
                }
            }

            return files;
        }
    }
}