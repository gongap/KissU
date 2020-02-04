using System;
using System.Linq;

namespace KissU.Core.EventBusRabbitMQ.Attributes
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
        /// Gets the name of the queue.
        /// </summary>
        public string QueueName
        {
            get { return _queueName; }
        }

        /// <summary>
        /// Gets the modes.
        /// </summary>
        public QueueConsumerMode[] Modes
        {
            get { return _modes; }
        }

        private string _queueName { get; set; }

        private QueueConsumerMode[] _modes { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueConsumerAttribute"/> class.
        /// </summary>
        /// <param name="queueName">Name of the queue.</param>
        /// <param name="modes">The modes.</param>
        public QueueConsumerAttribute(string queueName, params QueueConsumerMode[] modes)
        {
            _queueName = queueName;
            _modes = modes.Any() ? modes :
                new QueueConsumerMode[] { QueueConsumerMode.Normal };
        }

    }
}
