using System;
using System.Collections.Generic;
using KissU.AspNetCore.Swagger.Swagger.Model;

namespace KissU.AspNetCore.Swagger.SwaggerGen.Generator
{
    /// <summary>
    /// Interface ISchemaRegistry
    /// </summary>
    public interface ISchemaRegistry
    {
        /// <summary>
        /// Gets the definitions.
        /// </summary>
        IDictionary<string, Schema> Definitions { get; }

        /// <summary>
        /// Gets the or register.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>Schema.</returns>
        Schema GetOrRegister(Type type);

        /// <summary>
        /// Gets the or register.
        /// </summary>
        /// <param name="parmName">Name of the parm.</param>
        /// <param name="type">The type.</param>
        /// <returns>Schema.</returns>
        Schema GetOrRegister(string parmName, Type type);
    }
}