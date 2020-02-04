using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using KissU.Core.CPlatform.Runtime.Server;

namespace KissU.Core.Swagger.Internal
{
    /// <summary>
    /// DefaultServiceSchemaProvider.
    /// Implements the <see cref="KissU.Core.Swagger.Internal.IServiceSchemaProvider" />
    /// </summary>
    /// <seealso cref="KissU.Core.Swagger.Internal.IServiceSchemaProvider" />
    public class DefaultServiceSchemaProvider : IServiceSchemaProvider
    {
        private readonly IServiceEntryProvider _serviceEntryProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultServiceSchemaProvider"/> class.
        /// </summary>
        /// <param name="serviceEntryProvider">The service entry provider.</param>
        public DefaultServiceSchemaProvider( IServiceEntryProvider serviceEntryProvider)
        {
            _serviceEntryProvider = serviceEntryProvider;
        }

        /// <summary>
        /// Gets the schema files path.
        /// </summary>
        /// <returns>IEnumerable&lt;System.String&gt;.</returns>
        public IEnumerable<string> GetSchemaFilesPath()
        {
            var result = new List<string>();
            var assemblieFiles = _serviceEntryProvider.GetALLEntries()
                        .Select(p => p.Type.Assembly.Location).Distinct();

            foreach (var assemblieFile in assemblieFiles)
            {
                var fileSpan = assemblieFile.AsSpan();
                var path = $"{fileSpan.Slice(0, fileSpan.LastIndexOf(".")).ToString()}.xml";
                if (File.Exists(path))
                    result.Add(path);
            }
            return result;
        }
    }
}
