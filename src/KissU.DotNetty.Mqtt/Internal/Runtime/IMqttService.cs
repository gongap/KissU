using System.Threading.Tasks;
using KissU.CPlatform.Runtime.Client.Address.Resolvers.Implementation.Selectors.Implementation;
using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.CPlatform.Support.Attributes;
using KissU.Dependency;
using KissU.DotNetty.Mqtt.Internal.Messages;

namespace KissU.DotNetty.Mqtt.Internal.Runtime
{
    /// <summary>
    /// MqttService
    /// </summary>
    [ServiceBundle("Device")]
    public interface IMqttService : IServiceKey
    {
        /// <summary>
        /// Publishes the specified device identifier.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns>Task.</returns>
        [Command(ShuntStrategy = AddressSelectorMode.HashAlgorithm)]
        Task Publish(string deviceId, MqttWillMessage message);
    }
}