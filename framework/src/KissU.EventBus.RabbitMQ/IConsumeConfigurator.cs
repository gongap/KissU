using System;
using System.Collections.Generic;

namespace KissU.EventBus.RabbitMQ
{
    /// <summary>
    /// Interface IConsumeConfigurator
    /// </summary>
    public interface IConsumeConfigurator
    {
        /// <summary>
        /// Configures the specified consumers.
        /// </summary>
        /// <param name="consumers">The consumers.</param>
        void Configure(List<Type> consumers);

        /// <summary>
        /// Unconfigures the specified consumers.
        /// </summary>
        /// <param name="consumers">The consumers.</param>
        void Unconfigure(List<Type> consumers);
    }
}