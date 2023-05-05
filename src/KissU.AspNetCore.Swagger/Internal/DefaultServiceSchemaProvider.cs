using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using KissU.CPlatform.Runtime.Server;

namespace KissU.AspNetCore.Swagger.Internal
{
    /// <summary>
    /// DefaultServiceSchemaProvider.
    /// Implements the <see cref="IServiceSchemaProvider" />
    /// </summary>
    /// <seealso cref="IServiceSchemaProvider" />
    public class DefaultServiceSchemaProvider : IServiceSchemaProvider
    {
        private readonly IServiceEntryManager _serviceEntryProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultServiceSchemaProvider" /> class.
        /// </summary>
        /// <param name="serviceEntryProvider">The service entry provider.</param>
        public DefaultServiceSchemaProvider(IServiceEntryManager serviceEntryProvider)
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
            var directoryPath = Directory.GetCurrentDirectory();
            var result1  = Directory.GetFiles(directoryPath, "*.*", SearchOption.TopDirectoryOnly).ToList()
                .Where(t => t.EndsWith(".xml")).ToList();
            if (result1.Count > 0)
            {
                result.AddRange(result1);
            }

            var assemblieFiles = GetServiceEntries()
                .Select(p => p.Type.Assembly.Location).Distinct();
            foreach (var assemblieFile in assemblieFiles)
            {
                var fileSpan = assemblieFile.AsSpan();
                var path = $"{fileSpan.Slice(0, fileSpan.LastIndexOf(".")).ToString()}.xml";
                if (File.Exists(path))
                    result.Add(path);
            }

            return result.Distinct();
        }

        private IEnumerable<ServiceEntry> GetServiceEntries()
        {
            var packages = CPlatform.AppConfig.ServerOptions.Packages.FirstOrDefault(x=>x.TypeName=="AspNetCoreModule");
            if((packages?.Using?.Contains("AspNetCoreStageModule")).GetValueOrDefault())
            {
                return _serviceEntryProvider.GetAllEntries();
            }

            return  _serviceEntryProvider.GetEntries();
        }
    }
}