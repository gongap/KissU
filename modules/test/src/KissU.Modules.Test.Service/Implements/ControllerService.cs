using System.Threading.Tasks;
using KissU.DotNetty.Mqtt.Internal.Messages;
using KissU.DotNetty.Mqtt.Internal.Services;
using KissU.Modules.Test.Service.Contracts;
using KissU.Modules.Test.Service.Contracts.Models;

namespace KissU.Modules.Test.Service.Implements
{
    public class ControllerService : MqttBehavior, IControllerService
    {
        public override async Task<bool> Authorized(string username, string password)
        {
            bool result = false;
            if (username == "admin" && password == "123456")
                result= true;
            return await Task.FromResult(result);
        }

       public async Task<bool> IsOnline(string deviceId)
        {
            var text = await GetService<IManagerService>().SayHello("hello");
            return  await base.GetDeviceIsOnine(deviceId);
        }

        public async Task Publish(string deviceId, WillMessage message)
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
