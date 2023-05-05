using System.Collections.Concurrent;
using KissU.DotNetty.Mqtt.Internal.Messages;

namespace KissU.DotNetty.Mqtt.Internal.Services
{
    /// <summary>
    /// Interface IClientSessionService
    /// </summary>
    public interface IClientSessionService
    {
        /// <summary>
        /// Saves the message.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="sessionMessage">The session message.</param>
        void SaveMessage(string deviceId, SessionMessage sessionMessage);

        /// <summary>
        /// Gets the messages.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <returns>ConcurrentQueue&lt;SessionMessage&gt;.</returns>
        ConcurrentQueue<SessionMessage> GetMessages(string deviceId);
    }
}