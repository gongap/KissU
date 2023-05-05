using System.Threading.Tasks;
using KissU.DotNetty.Mqtt.Internal.Messages;
using KissU.DotNetty.Mqtt.Internal.Services;
using KissU.Msm.Sample.Service.Contracts;
using KissU.Msm.Sample.Service.Contracts.Models;

namespace KissU.Msm.Sample.Service.Implements
{
    public class DeviceService : MqttBehavior, IDeviceService
    {
        public override async Task<bool> AuthorizedAsync(string username, string password)
        {
            bool result = false;
            if (username == "admin" && password == "123456")
                result= true;
            return await Task.FromResult(result);
        }

       public async Task<bool> IsOnlineAsync(string deviceId)
        {
            var text = await GetService<IManagerService>().SayHelloAsync("hello");
            return  await base.GetDeviceIsOnine(deviceId);
        }

        public async Task PublishAsync(string deviceId, WillMessage message)
        {
            var willMessage = new MqttWillMessage
            {
                WillMessage = message.Message,
                Qos = message.Qos,
                Topic = message.Topic,
                WillRetain = message.WillRetain
            };
            await Publish(deviceId, willMessage);
            await RemotePublish(deviceId, willMessage);
        }
    }
}
