﻿using System;

namespace KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes
{
    /// <summary>
    /// 服务集标记
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface)]
    public class ServiceBundleAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBundleAttribute" /> class.
        /// </summary>
        /// <param name="routeTemplate">The route template.</param>
        /// <param name="isPrefix">if set to <c>true</c> [is prefix].</param>
        public ServiceBundleAttribute(string routeTemplate, bool isPrefix = true)
        {
            RouteTemplate = routeTemplate;
            IsPrefix = isPrefix;
        }

        /// <summary>
        /// 路由模板.
        /// </summary>
        public string RouteTemplate { get; }

        /// <summary>
        /// 是否为前缀.
        /// </summary>
        public bool IsPrefix { get; }
    }
}