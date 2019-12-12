using System.Threading.Tasks;
using KissU.Core.Protocol.Mqtt.Internal.Messages;

namespace KissU.Core.Protocol.Mqtt.Internal.Services
{
    public interface IWillService
    {
        void Add(string deviceid, MqttWillMessage willMessage);

        Task SendWillMessage(string deviceId);

        void Remove(string deviceid);
    }
}
