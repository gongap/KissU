using System.Collections.Generic;

namespace KissU.AspNetCore.Swagger.Internal
{
    /// <summary>
    /// Interface IServiceSchemaProvider
    /// </summary>
    public interface IServiceSchemaProvider
    {
        /// <summary>
        /// Gets the schema files path.
        /// </summary>
        /// <returns>IEnumerable&lt;System.String&gt;.</returns>
        IEnumerable<string> GetSchemaFilesPath();
    }
}