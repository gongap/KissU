using KissU.Surging.CPlatform.EventBus.Events;

namespace KissU.Modules.SampleA.Service.Contracts.Events
{
    /// <summary>
    /// LogoutEvent.
    /// Implements the <see cref="KissU.Surging.CPlatform.EventBus.Events.IntegrationEvent" />
    /// </summary>
    /// <seealso cref="KissU.Surging.CPlatform.EventBus.Events.IntegrationEvent" />
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