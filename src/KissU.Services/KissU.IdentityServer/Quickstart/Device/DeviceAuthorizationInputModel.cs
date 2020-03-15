using KissU.IdentityServer.Quickstart.Consent;

namespace KissU.IdentityServer.Quickstart.Device
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