using System.Collections.Generic;
using KissU.Core.CPlatform.Routing;

namespace KissU.Core.CPlatform.Runtime.Client
{
    /// <summary>
    /// 服务订阅描述符.
    /// </summary>
    public class ServiceSubscriberDescriptor
    {
        /// <summary>
        /// 服务地址描述符集合。
        /// </summary>
        public IEnumerable<ServiceAddressDescriptor> AddressDescriptors { get; set; }

        /// <summary>
        /// 服务描述符。
        /// </summary>
        public ServiceDescriptor ServiceDescriptor { get; set; }
    }
}