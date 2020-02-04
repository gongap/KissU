namespace KissU.Core.Swagger.SwaggerGen.Generator
{
    /// <summary>
    /// Interface ISchemaRegistryFactory
    /// </summary>
    public interface ISchemaRegistryFactory
    {
        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>ISchemaRegistry.</returns>
        ISchemaRegistry Create();
    }
}
