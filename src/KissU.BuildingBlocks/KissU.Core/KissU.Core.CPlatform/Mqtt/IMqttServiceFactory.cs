using System.Collections.Generic;
using System.Threading.Tasks;

namespace KissU.Core.CPlatform.Mqtt
{
    /// <summary>
    /// Mqtt服务工厂
    /// </summary>
    public interface IMqttServiceFactory
    {
        /// <summary>
        /// 根据Mqtt服务路由描述符创建Mqtt服务路由。
        /// </summary>
        /// <param name="descriptors">Mqtt服务路由描述符。</param>
        /// <returns>Mqtt服务路由集合。</returns>
        Task<IEnumerable<MqttServiceRoute>> CreateMqttServiceRoutesAsync(IEnumerable<MqttServiceDescriptor> descriptors);
    }
}