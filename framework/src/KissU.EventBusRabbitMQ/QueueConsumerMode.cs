namespace KissU.EventBusRabbitMQ
{
    /// <summary>
    /// Enum QueueConsumerMode
    /// </summary>
    public enum QueueConsumerMode
    {
        /// <summary>
        /// The normal
        /// </summary>
        Normal = 0,

        /// <summary>
        /// The retry
        /// </summary>
        Retry,

        /// <summary>
        /// The fail
        /// </summary>
        Fail
    }
}