using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissU.Core.CPlatform.Address;
using KissU.Core.CPlatform.Mqtt;
using KissU.Core.CPlatform.Mqtt.Implementation;
using KissU.Core.CPlatform.Runtime.Client.HealthChecks;
using KissU.Core.CPlatform.Runtime.Client.HealthChecks.Implementation;
using Microsoft.Extensions.Logging;

namespace KissU.Core.Protocol.Mqtt.Internal.Runtime.Implementation
{
    /// <summary>
    /// DefaultMqttBrokerEntryManager.
    /// Implements the <see cref="KissU.Core.Protocol.Mqtt.Internal.Runtime.IMqttBrokerEntryManger" />
    /// </summary>
    /// <seealso cref="KissU.Core.Protocol.Mqtt.Internal.Runtime.IMqttBrokerEntryManger" />
    public class DefaultMqttBrokerEntryManager : IMqttBrokerEntryManger
    {
        private readonly IMqttServiceRouteManager _mqttServiceRouteManager;
        private readonly ILogger<DefaultMqttBrokerEntryManager> _logger;
        private readonly ConcurrentDictionary<string, IEnumerable<AddressModel>> _brokerEntries =
            new ConcurrentDictionary<string, IEnumerable<AddressModel>>();

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultMqttBrokerEntryManager"/> class.
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
            await _mqttServiceRouteManager.RemoveByTopicAsync(topic, new AddressModel[] { addressModel });
        }

        /// <summary>
        /// Gets the MQTT broker address.
        /// </summary>
        /// <param name="topic">The topic.</param>
        /// <returns>ValueTask&lt;IEnumerable&lt;AddressModel&gt;&gt;.</returns>
        public async ValueTask<IEnumerable<AddressModel>> GetMqttBrokerAddress(string topic)
        {
            _brokerEntries.TryGetValue(topic, out IEnumerable<AddressModel> addresses);
            if (addresses==null || !addresses.Any())
            {
                var routes = await _mqttServiceRouteManager.GetRoutesAsync();
                var route=  routes.Where(p => p.MqttDescriptor.Topic == topic).SingleOrDefault();
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
            await _mqttServiceRouteManager.SetRoutesAsync(new MqttServiceRoute[]
            {
                new MqttServiceRoute
            {
                 MqttDescriptor=new MqttDescriptor
                {
                      Topic=topic
                 },
                  MqttEndpoint=new AddressModel[]
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
            _brokerEntries.TryRemove(key, out IEnumerable<AddressModel> value);
        }

        private void MqttRouteManager_Removed(object sender, HealthCheckEventArgs e)
        {
            if(!e.Health)
            _mqttServiceRouteManager.RemveAddressAsync(new AddressModel[] { e.Address });
        }
    }
}
