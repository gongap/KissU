using KissU.EventBus.Events;

namespace KissU.Services.SampleA.Contract.Events
{
    /// <summary>
    /// UserEvent.
    /// Implements the <see cref="IntegrationEvent" />
    /// </summary>
    /// <seealso cref="IntegrationEvent" />
    public class UserEvent : IntegrationEvent
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the age.
        /// </summary>
        public int Age { get; set; }
    }
}