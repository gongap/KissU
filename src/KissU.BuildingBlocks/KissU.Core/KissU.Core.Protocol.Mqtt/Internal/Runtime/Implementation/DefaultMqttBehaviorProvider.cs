﻿using System.Linq;
using KissU.Core.CPlatform;
using KissU.Core.CPlatform.Runtime.Server;
using KissU.Core.Protocol.Mqtt.Internal.Services;

namespace KissU.Core.Protocol.Mqtt.Internal.Runtime.Implementation
{
    /// <summary>
    /// DefaultMqttBehaviorProvider.
    /// Implements the <see cref="KissU.Core.Protocol.Mqtt.Internal.Runtime.IMqttBehaviorProvider" />
    /// </summary>
    /// <seealso cref="KissU.Core.Protocol.Mqtt.Internal.Runtime.IMqttBehaviorProvider" />
    public class DefaultMqttBehaviorProvider : IMqttBehaviorProvider
    {
        #region Field

        private readonly IServiceEntryProvider _serviceEntryProvider;
        private readonly CPlatformContainer _serviceProvider;
        private MqttBehavior _mqttBehavior;

        #endregion Field

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultMqttBehaviorProvider"/> class.
        /// </summary>
        /// <param name="serviceEntryProvider">The service entry provider.</param>
        /// <param name="serviceProvider">The service provider.</param>
        public DefaultMqttBehaviorProvider(IServiceEntryProvider serviceEntryProvider,  CPlatformContainer serviceProvider)
        {
            _serviceEntryProvider = serviceEntryProvider;
            _serviceProvider = serviceProvider;
        }

        #endregion Constructor

        /// <summary>
        /// Gets the MQTT behavior.
        /// </summary>
        /// <returns>MqttBehavior.</returns>
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
