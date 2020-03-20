﻿using System.Collections.Generic;
using System.Linq;
using KissU.Surging.CPlatform.Filters.Implementation;
using KissU.Surging.Swagger.Swagger.Model;
using KissU.Surging.Swagger.SwaggerGen.Generator;

namespace KissU.Surging.Swagger.Swagger.Filters
{
    /// <summary>
    /// AddAuthorizationOperationFilter.
    /// Implements the <see cref="KissU.Surging.Swagger.SwaggerGen.Generator.IOperationFilter" />
    /// </summary>
    /// <seealso cref="KissU.Surging.Swagger.SwaggerGen.Generator.IOperationFilter" />
    public class AddAuthorizationOperationFilter : IOperationFilter
    {
        /// <summary>
        /// Applies the specified operation.
        /// </summary>
        /// <param name="operation">The operation.</param>
        /// <param name="context">The context.</param>
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
            {
                operation.Parameters = new List<IParameter>();
            }


            var attribute =
                context.ServiceEntry.Attributes.Where(p => p is AuthorizationAttribute)
                    .Select(p => p as AuthorizationAttribute).FirstOrDefault();
            if (attribute != null && attribute.AuthType == AuthorizationType.JWT)
            {
                operation.Parameters.Add(new BodyParameter
                {
                    Name = "Authorization",
                    In = "header",
                    Required = false,
                    Schema = new Schema
                    {
                        Type = "string"
                    }
                });
            }
            else if (attribute != null && attribute.AuthType == AuthorizationType.AppSecret)
            {
                operation.Parameters.Add(new BodyParameter
                {
                    Name = "Authorization",
                    In = "header",
                    Required = false,
                    Schema = new Schema
                    {
                        Type = "string"
                    }
                });
                operation.Parameters.Add(new BodyParameter
                {
                    Name = "timeStamp",
                    In = "query",
                    Required = false,
                    Schema = new Schema
                    {
                        Type = "string"
                    }
                });
            }
        }
    }
}