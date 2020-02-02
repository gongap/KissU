using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KissU.Core.CPlatform.Runtime.Server
{
    /// <summary>
    /// 服务条目。
    /// </summary>
    public class ServiceEntry
    {
        /// <summary>
        /// 执行委托。
        /// </summary>
        public Func<string, IDictionary<string, object>, Task<object>> Func { get; set; }

        /// <summary>
        /// 方法.
        /// </summary>
        public IEnumerable<string> Methods { get; set; }

        /// <summary>
        /// 路由地址.
        /// </summary>
        public string RoutePath { get; set; }

        /// <summary>
        /// 类型.
        /// </summary>
        public Type Type { get; set; }

        /// <summary>
        /// 方法名称.
        /// </summary>
        public string MethodName { get; set; }

        /// <summary>
        /// 属性集合.
        /// </summary>
        public List<Attribute> Attributes { get; set; }

        /// <summary>
        /// 服务描述符。
        /// </summary>
        public ServiceDescriptor Descriptor { get; set; }
    }
}