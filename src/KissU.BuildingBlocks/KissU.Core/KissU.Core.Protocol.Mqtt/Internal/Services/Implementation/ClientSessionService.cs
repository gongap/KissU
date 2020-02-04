﻿using System;
using System.Collections.Concurrent;
using KissU.Core.Protocol.Mqtt.Internal.Messages;

namespace KissU.Core.Protocol.Mqtt.Internal.Services.Implementation
{
    /// <summary>
    /// ClientSessionService.
    /// Implements the <see cref="KissU.Core.Protocol.Mqtt.Internal.Services.IClientSessionService" />
    /// </summary>
    /// <seealso cref="KissU.Core.Protocol.Mqtt.Internal.Services.IClientSessionService" />
    public class ClientSessionService: IClientSessionService
    {
        private  readonly ConcurrentDictionary<String, ConcurrentQueue<SessionMessage>> _clientsessionMessages = 
            new ConcurrentDictionary<String, ConcurrentQueue<SessionMessage>>();

        /// <summary>
        /// Gets the messages.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <returns>ConcurrentQueue&lt;SessionMessage&gt;.</returns>
        public ConcurrentQueue<SessionMessage> GetMessages(string deviceId)
        {
            _clientsessionMessages.TryGetValue(deviceId, out ConcurrentQueue<SessionMessage> messages);
            return messages;
        }

        /// <summary>
        /// Saves the message.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="sessionMessage">The session message.</param>
        public void SaveMessage(string deviceId, SessionMessage sessionMessage)
        {
            _clientsessionMessages.TryGetValue(deviceId, out ConcurrentQueue<SessionMessage> sessionMessages);
            _clientsessionMessages.AddOrUpdate(deviceId, sessionMessages, (id, message) =>
            {
                message.Enqueue(sessionMessage);
                return sessionMessages;
            });
        }
    }
}
