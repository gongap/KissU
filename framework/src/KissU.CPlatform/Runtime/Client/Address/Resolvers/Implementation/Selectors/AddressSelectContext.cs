﻿using System.Collections.Generic;
using KissU.Address;

namespace KissU.CPlatform.Runtime.Client.Address.Resolvers.Implementation.Selectors
{
    /// <summary>
    /// 地址选择上下文。
    /// </summary>
    public class AddressSelectContext
    {
        /// <summary>
        /// 服务描述符。
        /// </summary>
        public ServiceDescriptor Descriptor { get; set; }

        /// <summary>
        /// 哈希参数
        /// </summary>
        public string Item { get; set; }

        /// <summary>
        /// 服务可用地址。
        /// </summary>
        public IEnumerable<AddressModel> Address { get; set; }
    }
}