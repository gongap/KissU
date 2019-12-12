using System;

namespace KissU.Core.EventBusKafka
{
   public interface IKafkaPersisterConnection : IDisposable
    {
        bool IsConnected { get; }

        bool TryConnect();

        Object CreateConnect();
    }
}
