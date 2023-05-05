using System.Collections.Generic;
using KissU.AspNetCore.Swagger.Swagger.Model;
using KissU.AspNetCore.Swagger.SwaggerGen.Generator;
using KissU.CPlatform;

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

            var enableAuthorization = context.ServiceEntry.Descriptor.EnableAuthorization();
            if(enableAuthorization)
            {
                operation.Parameters.Add(new BodyParameter
                {
                    Name = "Authorization",
                    In = "header",
                    Required = false,
                    Description = "访问令牌",
                    Schema = new Schema
                    {
                        Type = "string"
                    }
                });
            }

            //var authorizationAttribute = context.ServiceEntry.Attributes.OfType<AuthorizationAttribute>().FirstOrDefault();
            //if (authorizationAttribute != null && (authorizationAttribute.AuthType == AuthorizationType.AppSecret || authorizationAttribute.AuthType == AuthorizationType.JwtSecret))
            //{
            //    operation.Parameters.Add(new BodyParameter
            //    {
            //        Name = "AppSecret",
            //        In = "header",
            //        Required = false,
            //        Description = "密钥",
            //        Schema = new Schema
            //        {
            //            Type = "string"
            //        }
            //    });
            //    operation.Parameters.Add(new BodyParameter
            //    {
            //        Name = "Timestamp",
            //        In = "header",
            //        Required = false,
            //        Description = "时间戳",
            //        Schema = new Schema
            //        {
            //            Type = "string"
            //        }
            //    });
            //}
        }
    }
}