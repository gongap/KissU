using System.Collections.Concurrent;
using KissU.DotNetty.Mqtt.Internal.Messages;

namespace KissU.DotNetty.Mqtt.Internal.Services.Implementation
{
    /// <summary>
    /// ClientSessionService.
    /// Implements the <see cref="IClientSessionService" />
    /// </summary>
    /// <seealso cref="IClientSessionService" />
    public class ClientSessionService : IClientSessionService
    {
        private readonly ConcurrentDictionary<string, ConcurrentQueue<SessionMessage>> _clientsessionMessages =
            new ConcurrentDictionary<string, ConcurrentQueue<SessionMessage>>();

        /// <summary>
        /// Gets the messages.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <returns>ConcurrentQueue&lt;SessionMessage&gt;.</returns>
        public ConcurrentQueue<SessionMessage> GetMessages(string deviceId)
        {
            _clientsessionMessages.TryGetValue(deviceId, out var messages);
            return messages;
        }

        /// <summary>
        /// Saves the message.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="sessionMessage">The session message.</param>
        public void SaveMessage(string deviceId, SessionMessage sessionMessage)
        {
            _clientsessionMessages.TryGetValue(deviceId, out var sessionMessages);
            _clientsessionMessages.AddOrUpdate(deviceId, sessionMessages, (id, message) =>
            {
                message.Enqueue(sessionMessage);
                return sessionMessages;
            });
        }
    }
}