using System.Linq;
using KissU.Core.CPlatform;
using KissU.Core.CPlatform.Runtime.Server;
using KissU.Core.Protocol.Mqtt.Internal.Services;

namespace KissU.Core.Protocol.Mqtt.Internal.Runtime.Implementation
{
    public class DefaultMqttBehaviorProvider : IMqttBehaviorProvider
    {
        #region Field

        private readonly IServiceEntryProvider _serviceEntryProvider;
        private readonly CPlatformContainer _serviceProvider;
        private MqttBehavior _mqttBehavior;

        #endregion Field

        #region Constructor

        public DefaultMqttBehaviorProvider(IServiceEntryProvider serviceEntryProvider,  CPlatformContainer serviceProvider)
        {
            _serviceEntryProvider = serviceEntryProvider;
            _serviceProvider = serviceProvider;
        }

        #endregion Constructor

        public MqttBehavior GetMqttBehavior()
        {
            if (_mqttBehavior == null)
            {
                 _mqttBehavior = _serviceEntryProvider.GetTypes()
                    .Select(type=> _serviceProvider.GetInstances(type) as MqttBehavior ).Where(p=>p!=null).FirstOrDefault(); 
            }
            return _mqttBehavior;
        }
    }
}
