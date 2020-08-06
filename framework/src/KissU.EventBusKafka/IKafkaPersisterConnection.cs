using System;

namespace KissU.EventBusKafka
{
    /// <summary>
    /// Interface IKafkaPersisterConnection
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface IKafkaPersisterConnection : IDisposable
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
        /// Creates the connect.
        /// </summary>
        /// <returns>Object.</returns>
        object CreateConnect();
    }
}