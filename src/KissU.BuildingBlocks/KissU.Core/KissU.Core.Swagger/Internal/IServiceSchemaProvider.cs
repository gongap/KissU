using System.Collections.Generic;

namespace KissU.Core.Swagger.Internal
{
   public interface IServiceSchemaProvider
    {
        IEnumerable<string> GetSchemaFilesPath();
    }
}
