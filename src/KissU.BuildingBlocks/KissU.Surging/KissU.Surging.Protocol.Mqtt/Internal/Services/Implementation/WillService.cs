using System.Collections.Concurrent;
using System.Threading.Tasks;
using KissU.Core;
using KissU.Surging.Protocol.Mqtt.Internal.Messages;
using Microsoft.Extensions.Logging;

namespace KissU.Surging.Protocol.Mqtt.Internal.Services.Implementation
{
    /// <summary>
    /// WillService.
    /// Implements the <see cref="KissU.Surging.Protocol.Mqtt.Internal.Services.IWillService" />
    /// </summary>
    /// <seealso cref="KissU.Surging.Protocol.Mqtt.Internal.Services.IWillService" />
    public class WillService : IWillService
    {
        private readonly ILogger<WillService> _logger;
        private readonly CPlatformContainer _serviceProvider;

        private readonly ConcurrentDictionary<string, MqttWillMessage> willMeaasges =
            new ConcurrentDictionary<string, MqttWillMessage>();

        /// <summary>
        /// Initializes a new instance of the <see cref="WillService" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="serviceProvider">The service provider.</param>
        public WillService(ILogger<WillService> logger, CPlatformContainer serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Adds the specified deviceid.
        /// </summary>
        /// <param name="deviceid">The deviceid.</param>
        /// <param name="willMessage">The will message.</param>
        public void Add(string deviceid, MqttWillMessage willMessage)
        {
            willMeaasges.AddOrUpdate(deviceid, willMessage, (id, message) => willMessage);
        }

        /// <summary>
        /// Sends the will message.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        public async Task SendWillMessage(string deviceId)
        {
            if (!string.IsNullOrEmpty(deviceId))
            {
                willMeaasges.TryGetValue(deviceId, out var willMessage);
                if (willMeaasges != null)
                {
                    await _serviceProvider.GetInstances<IChannelService>().SendWillMsg(willMessage);
                    if (!willMessage.WillRetain)
                    {
                        Remove(deviceId);
                        if (_logger.IsEnabled(LogLevel.Information))
                            _logger.LogInformation($"deviceId:{deviceId} 的遗嘱消息[" + willMessage.WillMessage + "] 已经被删除");
                    }
                }
            }
        }

        /// <summary>
        /// Removes the specified deviceid.
        /// </summary>
        /// <param name="deviceid">The deviceid.</param>
        public void Remove(string deviceid)
        {
            willMeaasges.TryRemove(deviceid, out var message);
        }
    }
}