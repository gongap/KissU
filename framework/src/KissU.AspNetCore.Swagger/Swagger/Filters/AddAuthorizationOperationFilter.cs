﻿using System.Collections.Generic;
using System.Linq;
using KissU.AspNetCore.Swagger.Swagger.Model;
using KissU.AspNetCore.Swagger.SwaggerGen.Generator;
using KissU.CPlatform.Filters.Implementation;

namespace KissU.AspNetCore.Swagger.Swagger.Filters
{
    /// <summary>
    /// AddAuthorizationOperationFilter.
    /// Implements the <see cref="IOperationFilter" />
    /// </summary>
    /// <seealso cref="IOperationFilter" />
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
                context.ServiceEntry.Attributes.Where(p => p is AuthorizationAttribute) .Select(p => p as AuthorizationAttribute).FirstOrDefault();
            if (attribute != null && attribute.AuthType == AuthorizationType.JWT)
            {
                operation.Parameters.Add(new BodyParameter
                {
                    Name = "Authorization",
                    In = "header",
                    Required = false,
                    Description = "令牌",
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
                    Description = "令牌",
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
                    Description="时间戳",
                    Schema = new Schema
                    {
                        Type = "string"
                    }
                });
            }
        }
    }
}