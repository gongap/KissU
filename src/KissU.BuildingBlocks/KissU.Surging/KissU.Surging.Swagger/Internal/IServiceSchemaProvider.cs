using System.Collections.Generic;

namespace KissU.Surging.Swagger.Internal
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