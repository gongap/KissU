using System;
using System.Linq;

namespace KissU.EventBus.RabbitMQ.Attributes
{
    /// <summary>
    /// QueueConsumerAttribute.
    /// Implements the <see cref="System.Attribute" />
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
    public class QueueConsumerAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueueConsumerAttribute" /> class.
        /// </summary>
        /// <param name="queueName">Name of the queue.</param>
        /// <param name="modes">The modes.</param>
        public QueueConsumerAttribute(string queueName, params QueueConsumerMode[] modes)
        {
            _queueName = queueName;
            _modes = modes.Any() ? modes : new[] {QueueConsumerMode.Normal};
        }

        /// <summary>
        /// Gets the name of the queue.
        /// </summary>
        public string QueueName => _queueName;

        /// <summary>
        /// Gets the modes.
        /// </summary>
        public QueueConsumerMode[] Modes => _modes;

        private string _queueName { get; }

        private QueueConsumerMode[] _modes { get; }
    }
}