using System;
using System.Collections.Generic;
using KissU.Core.Swagger.Swagger.Model;

namespace KissU.Core.Swagger.SwaggerGen.Generator
{
    public interface ISchemaRegistry
    {
        Schema GetOrRegister(Type type);

        Schema GetOrRegister(string parmName, Type type);

        IDictionary<string, Schema> Definitions { get; }
    }
}
