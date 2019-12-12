using System.Collections.Concurrent;
using KissU.Core.Protocol.Mqtt.Internal.Messages;

namespace KissU.Core.Protocol.Mqtt.Internal.Services
{
   public interface IClientSessionService
    {
        void SaveMessage(string deviceId, SessionMessage sessionMessage);

        ConcurrentQueue<SessionMessage> GetMessages(string deviceId);
    }
}
