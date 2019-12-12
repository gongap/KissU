﻿using System.Reflection;
using KissU.Core.CPlatform.Runtime.Server;
using KissU.Core.Swagger.Swagger.Model;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace KissU.Core.Swagger.SwaggerGen.Generator
{
    public interface IOperationFilter
    {
        void Apply(Operation operation, OperationFilterContext context);
    }

    public class OperationFilterContext
    {
        public OperationFilterContext(
            ApiDescription apiDescription,
            ISchemaRegistry schemaRegistry,
            MethodInfo methodInfo):this(apiDescription,schemaRegistry,methodInfo,null)
        {
             
        }

        public OperationFilterContext(
       ApiDescription apiDescription,
       ISchemaRegistry schemaRegistry,
       MethodInfo methodInfo,ServiceEntry serviceEntry)
        {
            ApiDescription = apiDescription;
            SchemaRegistry = schemaRegistry;
            MethodInfo = methodInfo;
            ServiceEntry = serviceEntry;
        }

        public ServiceEntry ServiceEntry { get; set; }

        public ApiDescription ApiDescription { get; private set; }

        public ISchemaRegistry SchemaRegistry { get; private set; }

        public MethodInfo MethodInfo { get; }
    }
}
