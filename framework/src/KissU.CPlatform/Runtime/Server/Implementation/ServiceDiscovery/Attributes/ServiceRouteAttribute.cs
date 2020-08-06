using System;

namespace KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes
{
    /// <summary>
    /// 服务路由属性.
    /// Implements the <see cref="Attribute" />
    /// </summary>
    /// <seealso cref="Attribute" />
    public class ServiceRouteAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceRouteAttribute" /> class.
        /// </summary>
        /// <param name="template">The template.</param>
        public ServiceRouteAttribute(string template)
        {
            Template = template;
        }

        /// <summary>
        /// 模板.
        /// </summary>
        public string Template { get; }
    }
}