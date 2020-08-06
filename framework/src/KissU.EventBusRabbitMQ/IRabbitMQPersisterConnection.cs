using System;
using RabbitMQ.Client;

namespace KissU.EventBusRabbitMQ
{
    /// <summary>
    /// Interface IRabbitMQPersistentConnection
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface IRabbitMQPersistentConnection
        : IDisposable
    {
        /// <summary>
        /// Gets a value indicating whether this instance is connected.
        /// </summary>
        bool IsConnected { get; }

        /// <summary>
        /// Tries the connect.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool TryConnect();

        /// <summary>
        /// Creates the model.
        /// </summary>
        /// <returns>IModel.</returns>
        IModel CreateModel();

        /// <summary>
        /// Occurs when [on rabbit connection shutdown].
        /// </summary>
        event EventHandler<ShutdownEventArgs> OnRabbitConnectionShutdown;
    }
}