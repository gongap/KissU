﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace KissU.CPlatform.Runtime.Client
{
    /// <summary>
    /// 服务订阅者工厂接口
    /// </summary>
    public interface IServiceSubscriberFactory
    {
        /// <summary>
        /// 根据服务描述创建服务订阅者.
        /// </summary>
        /// <param name="descriptors">The descriptors.</param>
        /// <returns>Task&lt;IEnumerable&lt;ServiceSubscriber&gt;&gt;.</returns>
        Task<IEnumerable<ServiceSubscriber>> CreateServiceSubscribersAsync(
            IEnumerable<ServiceSubscriberDescriptor> descriptors);
    }
}