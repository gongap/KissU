using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissU.Address;
using KissU.CPlatform.Mqtt;
using KissU.CPlatform.Mqtt.Implementation;
using KissU.CPlatform.Runtime.Client.HealthChecks;
using KissU.CPlatform.Runtime.Client.HealthChecks.Implementation;
using Microsoft.Extensions.Logging;

namespace KissU.DotNetty.Mqtt.Internal.Runtime.Implementation
{
    /// <summary>
    /// DefaultMqttBrokerEntryManager.
    /// Implements the <see cref="IMqttBrokerEntryManger" />
    /// </summary>
    /// <seealso cref="IMqttBrokerEntryManger" />
    public class DefaultMqttBrokerEntryManager : IMqttBrokerEntryManger
    {
        private readonly ConcurrentDictionary<string, IEnumerable<AddressModel>> _brokerEntries =
            new ConcurrentDictionary<string, IEnumerable<AddressModel>>();

        private readonly ILogger<DefaultMqttBrokerEntryManager> _logger;
        private readonly IMqttServiceRouteManager _mqttServiceRouteManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultMqttBrokerEntryManager" /> class.
        /// </summary>
        /// <param name="mqttServiceRouteManager">The MQTT service route manager.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="healthCheckService">The health check service.</param>
        public DefaultMqttBrokerEntryManager(IMqttServiceRouteManager mqttServiceRouteManager,
            ILogger<DefaultMqttBrokerEntryManager> logger, IHealthCheckService healthCheckService)
        {
            _mqttServiceRouteManager = mqttServiceRouteManager;
            _logger = logger;
            _mqttServiceRouteManager.Changed += MqttRouteManager_Removed;
            _mqttServiceRouteManager.Removed += MqttRouteManager_Removed;
            healthCheckService.Removed += MqttRouteManager_Removed;
        }

        /// <summary>
        /// Cancellations the reg.
        /// </summary>
        /// <param name="topic">The topic.</param>
        /// <param name="addressModel">The address model.</param>
        public async Task CancellationReg(string topic, AddressModel addressModel)
        {
            await _mqttServiceRouteManager.RemoveByTopicAsync(topic, new[] {addressModel});
        }

        /// <summary>
        /// Gets the MQTT broker address.
        /// </summary>
        /// <param name="topic">The topic.</param>
        /// <returns>ValueTask&lt;IEnumerable&lt;AddressModel&gt;&gt;.</returns>
        public async ValueTask<IEnumerable<AddressModel>> GetMqttBrokerAddress(string topic)
        {
            _brokerEntries.TryGetValue(topic, out var addresses);
            if (addresses == null || !addresses.Any())
            {
                var routes = await _mqttServiceRouteManager.GetRoutesAsync();
                var route = routes.Where(p => p.MqttDescriptor.Topic == topic).SingleOrDefault();
                if (route != null)
                {
                    _brokerEntries.TryAdd(topic, route.MqttEndpoint);
                    addresses = route.MqttEndpoint;
                }
            }

            return addresses;
        }

        /// <summary>
        /// Registers the specified topic.
        /// </summary>
        /// <param name="topic">The topic.</param>
        /// <param name="addressModel">The address model.</param>
        public async Task Register(string topic, AddressModel addressModel)
        {
            await _mqttServiceRouteManager.SetRoutesAsync(new[]
            {
                new MqttServiceRoute
                {
                    MqttDescriptor = new MqttDescriptor
                    {
                        Topic = topic
                    },
                    MqttEndpoint = new[]
                    {
                        addressModel
                    }
                }
            });
        }

        private static string GetCacheKey(MqttDescriptor descriptor)
        {
            return descriptor.Topic;
        }

        private void MqttRouteManager_Removed(object sender, MqttServiceRouteEventArgs e)
        {
            var key = GetCacheKey(e.Route.MqttDescriptor);
            _brokerEntries.TryRemove(key, out var value);
        }

        private void MqttRouteManager_Removed(object sender, HealthCheckEventArgs e)
        {
            if (!e.Health)
                _mqttServiceRouteManager.RemveAddressAsync(new[] {e.Address});
        }
    }
}