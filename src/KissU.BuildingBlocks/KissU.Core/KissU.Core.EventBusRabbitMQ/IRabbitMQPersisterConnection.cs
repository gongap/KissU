using System;
using RabbitMQ.Client;

namespace KissU.Core.EventBusRabbitMQ
{
    public interface IRabbitMQPersistentConnection
         : IDisposable
    {
        bool IsConnected { get; }

        bool TryConnect();

        IModel CreateModel();

        event EventHandler<ShutdownEventArgs> OnRabbitConnectionShutdown;
    }
}