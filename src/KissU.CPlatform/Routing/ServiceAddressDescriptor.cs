﻿using Newtonsoft.Json;

namespace KissU.CPlatform.Routing
{
    /// <summary>
    /// 服务地址描述符。
    /// </summary>
    public class ServiceAddressDescriptor
    {
        /// <summary>
        /// 地址类型。
        /// </summary>
        [JsonIgnore]
        public string Type { get; set; }

        /// <summary>
        /// 地址值。
        /// </summary>
        public string Value { get; set; }
    }
}