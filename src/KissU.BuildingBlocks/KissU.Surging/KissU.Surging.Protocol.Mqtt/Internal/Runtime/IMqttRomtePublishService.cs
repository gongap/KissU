using System.Threading.Tasks;
using KissU.Surging.CPlatform.Ioc;
using KissU.Surging.CPlatform.Runtime.Client.Address.Resolvers.Implementation.Selectors.Implementation;
using KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Surging.CPlatform.Support.Attributes;
using KissU.Surging.Protocol.Mqtt.Internal.Messages;

namespace KissU.Surging.Protocol.Mqtt.Internal.Runtime
{
    /// <summary>
    /// Interface IMqttRomtePublishService
    /// Implements the <see cref="KissU.Surging.CPlatform.Ioc.IServiceKey" />
    /// </summary>
    /// <seealso cref="KissU.Surging.CPlatform.Ioc.IServiceKey" />
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