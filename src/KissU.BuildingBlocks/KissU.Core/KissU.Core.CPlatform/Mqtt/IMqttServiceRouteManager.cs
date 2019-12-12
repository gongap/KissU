﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Core.CPlatform.Address;
using KissU.Core.CPlatform.Mqtt.Implementation;

namespace KissU.Core.CPlatform.Mqtt
{
   public interface IMqttServiceRouteManager
    {
        event EventHandler<MqttServiceRouteEventArgs> Created;

        event EventHandler<MqttServiceRouteEventArgs> Removed;

        event EventHandler<MqttServiceRouteChangedEventArgs> Changed;
         
        Task<IEnumerable<MqttServiceRoute>> GetRoutesAsync();

        /// <summary>
        /// 设置服务路由。
        /// </summary>
        /// <param name="routes">服务路由集合。</param>
        /// <returns>一个任务。</returns>
        Task SetRoutesAsync(IEnumerable<MqttServiceRoute> routes);

        Task RemoveByTopicAsync(string topic, IEnumerable<AddressModel> endpoint);


        Task RemveAddressAsync(IEnumerable<AddressModel> addresses);
        /// <summary>
        /// 清空所有的服务路由。
        /// </summary>
        /// <returns>一个任务。</returns>
        Task ClearAsync();
    }
}
