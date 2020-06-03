namespace KissU.EventBus.Events
{
    /// <summary>
    /// 事件上下文.
    /// Implements the <see cref="IntegrationEvent" />
    /// </summary>
    /// <seealso cref="IntegrationEvent" />
    public class EventContext : IntegrationEvent
    {
        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        public object Content { get; set; }

        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        public long Count { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public string Type { get; set; }
    }
}