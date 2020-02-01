using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Core.CPlatform.Address;
using KissU.Core.CPlatform.Mqtt.Implementation;

namespace KissU.Core.CPlatform.Mqtt
{
    /// <summary>
    /// Mqtt服务路线管理器
    /// </summary>
    public interface IMqttServiceRouteManager
    {
        /// <summary>
        /// Occurs when [created].
        /// </summary>
        event EventHandler<MqttServiceRouteEventArgs> Created;

        /// <summary>
        /// Occurs when [removed].
        /// </summary>
        event EventHandler<MqttServiceRouteEventArgs> Removed;

        /// <summary>
        /// Occurs when [changed].
        /// </summary>
        event EventHandler<MqttServiceRouteChangedEventArgs> Changed;

        /// <summary>
        /// Gets the routes asynchronous.
        /// </summary>
        /// <returns>Task&lt;IEnumerable&lt;MqttServiceRoute&gt;&gt;.</returns>
        Task<IEnumerable<MqttServiceRoute>> GetRoutesAsync();

        /// <summary>
        /// 设置服务路由。
        /// </summary>
        /// <param name="routes">服务路由集合。</param>
        /// <returns>一个任务。</returns>
        Task SetRoutesAsync(IEnumerable<MqttServiceRoute> routes);

        /// <summary>
        /// Removes the by topic asynchronous.
        /// </summary>
        /// <param name="topic">The topic.</param>
        /// <param name="endpoint">The endpoint.</param>
        /// <returns>Task.</returns>
        Task RemoveByTopicAsync(string topic, IEnumerable<AddressModel> endpoint);


        /// <summary>
        /// Remves the address asynchronous.
        /// </summary>
        /// <param name="addresses">The addresses.</param>
        /// <returns>Task.</returns>
        Task RemveAddressAsync(IEnumerable<AddressModel> addresses);

        /// <summary>
        /// 清空所有的服务路由。
        /// </summary>
        /// <returns>一个任务。</returns>
        Task ClearAsync();
    }
}