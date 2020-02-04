using System.Threading.Tasks;
using KissU.Core.Protocol.Mqtt.Internal.Messages;

namespace KissU.Core.Protocol.Mqtt.Internal.Services
{
    /// <summary>
    /// Interface IWillService
    /// </summary>
    public interface IWillService
    {
        /// <summary>
        /// Adds the specified deviceid.
        /// </summary>
        /// <param name="deviceid">The deviceid.</param>
        /// <param name="willMessage">The will message.</param>
        void Add(string deviceid, MqttWillMessage willMessage);

        /// <summary>
        /// Sends the will message.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <returns>Task.</returns>
        Task SendWillMessage(string deviceId);

        /// <summary>
        /// Removes the specified deviceid.
        /// </summary>
        /// <param name="deviceid">The deviceid.</param>
        void Remove(string deviceid);
    }
}
