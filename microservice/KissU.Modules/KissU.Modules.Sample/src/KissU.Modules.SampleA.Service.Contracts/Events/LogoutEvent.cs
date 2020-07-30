using KissU.EventBus.Events;

namespace KissU.Services.SampleA.Contract.Events
{
    /// <summary>
    /// LogoutEvent.
    /// Implements the <see cref="IntegrationEvent" />
    /// </summary>
    /// <seealso cref="IntegrationEvent" />
    public class LogoutEvent : IntegrationEvent
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the age.
        /// </summary>
        public string Age { get; set; }
    }
}