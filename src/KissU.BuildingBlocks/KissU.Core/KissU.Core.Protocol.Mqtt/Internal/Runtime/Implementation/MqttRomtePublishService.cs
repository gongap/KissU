using System.Threading.Tasks;
using KissU.Core.CPlatform.Ioc;
using KissU.Core.CPlatform.Utilities;
using KissU.Core.Protocol.Mqtt.Internal.Messages;
using KissU.Core.Protocol.Mqtt.Internal.Services;

namespace KissU.Core.Protocol.Mqtt.Internal.Runtime.Implementation
{
    public class MqttRomtePublishService : ServiceBase, IMqttRomtePublishService
    {
       public async Task Publish(string deviceId, MqttWillMessage message)
        {
            await ServiceLocator.GetService<IChannelService>().Publish(deviceId, message);
        }
    }
}
