using System;
using System.Collections.Generic;
using System.Reflection;

namespace KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery
{
    /// <summary>
    /// 一个抽象的Clr服务条目工厂。
    /// </summary>
    public interface IClrServiceEntryFactory
    {
        /// <summary>
        /// 创建服务条目。
        /// </summary>
        /// <param name="service">服务类型。</param>
        /// <returns>服务条目集合。</returns>
        IEnumerable<ServiceEntry> CreateServiceEntry(Type service, string defaultRouteTemplate= "api/{Service}/{Async}",  Func<MethodInfo, bool> disableNetwork = null, Func<MethodInfo, bool> enableAuthorization = null);
    }
}