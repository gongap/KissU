using System;
using System.Collections.Generic;
using System.Linq;

namespace KissU.Surging.Kestrel.Swagger.SwaggerGen.Generator
{
    /// <summary>
    /// SchemaIdManager.
    /// </summary>
    public class SchemaIdManager
    {
        private readonly IDictionary<Type, string> _schemaIdMap;
        private readonly Func<Type, string> _schemaIdSelector;

        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaIdManager" /> class.
        /// </summary>
        /// <param name="schemaIdSelector">The schema identifier selector.</param>
        public SchemaIdManager(Func<Type, string> schemaIdSelector)
        {
            _schemaIdSelector = schemaIdSelector;
            _schemaIdMap = new Dictionary<Type, string>();
        }

        /// <summary>
        /// Identifiers for.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public string IdFor(Type type)
        {
            if (!_schemaIdMap.TryGetValue(type, out var schemaId))
            {
                schemaId = _schemaIdSelector(type);

                // Raise an exception if another type with same schemaId
                if (_schemaIdMap.Any(entry => entry.Value == schemaId))
                    throw new InvalidOperationException(string.Format(
                        "Conflicting schemaIds: Identical schemaIds detected for types {0} and {1}. " +
                        "See config settings - \"CustomSchemaIds\" for a workaround",
                        type.FullName, _schemaIdMap.First(entry => entry.Value == schemaId).Key));

                _schemaIdMap.Add(type, schemaId);
            }

            return schemaId;
        }
    }
}