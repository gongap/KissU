using System;

namespace KissU.Util.Datas.Tests.Integration.Sql.Builders.Samples
{
    /// <summary>
    /// TestEntityMatedata.
    /// Implements the <see cref="IEntityMatedata" />
    /// </summary>
    /// <seealso cref="IEntityMatedata" />
    public class TestEntityMatedata : IEntityMatedata
    {
        /// <summary>
        /// Gets the table.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>System.String.</returns>
        public string GetTable(Type entity)
        {
            return $"t_{entity.Name}";
        }

        /// <summary>
        /// Gets the schema.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>System.String.</returns>
        public string GetSchema(Type entity)
        {
            return $"as_{entity.Name}";
        }

        /// <summary>
        /// Gets the column.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="property">The property.</param>
        /// <returns>System.String.</returns>
        public string GetColumn(Type entity, string property)
        {
            if (property == "DecimalValue")
                return property;
            return $"{entity.Name}_{property}";
        }
    }
}