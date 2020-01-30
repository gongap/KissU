using System;

namespace KissU.Core.CPlatform.EventBus.Events
{
    /// <summary>
    /// 集成事件.
    /// </summary>
    public class IntegrationEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IntegrationEvent"/> class.
        /// </summary>
        public IntegrationEvent()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IntegrationEvent"/> class.
        /// </summary>
        /// <param name="integrationEvent">The integration event.</param>
        public IntegrationEvent(IntegrationEvent integrationEvent)
        {
            Id = integrationEvent.Id;
            CreationDate = integrationEvent.CreationDate;
        }

        /// <summary>
        /// 标识.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// 创建日期.
        /// </summary>
        public DateTime CreationDate { get; }
    }
}
