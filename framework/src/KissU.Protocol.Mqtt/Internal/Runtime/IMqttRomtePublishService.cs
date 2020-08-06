using System.Threading.Tasks;
using KissU.Dependency;
using KissU.CPlatform.Runtime.Client.Address.Resolvers.Implementation.Selectors.Implementation;
using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.CPlatform.Support.Attributes;
using KissU.Protocol.Mqtt.Internal.Messages;

namespace KissU.Protocol.Mqtt.Internal.Runtime
{
    /// <summary>
    /// Interface IMqttRomtePublishService
    /// Implements the <see cref="IServiceKey" />
    /// </summary>
    /// <seealso cref="IServiceKey" />
    [ServiceBundle("Device")]
    public interface IMqttRomtePublishService : IServiceKey
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