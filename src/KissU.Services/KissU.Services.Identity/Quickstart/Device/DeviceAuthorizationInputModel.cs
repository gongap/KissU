using KissU.Services.Identity.Quickstart.Consent;

namespace KissU.Services.Identity.Quickstart.Device
{
    /// <summary>
    /// DeviceAuthorizationInputModel.
    /// Implements the <see cref="ConsentInputModel" />
    /// </summary>
    /// <seealso cref="ConsentInputModel" />
    public class DeviceAuthorizationInputModel : ConsentInputModel
    {
        /// <summary>
        /// Gets or sets the user code.
        /// </summary>
        /// <value>The user code.</value>
        public string UserCode { get; set; }
    }
}