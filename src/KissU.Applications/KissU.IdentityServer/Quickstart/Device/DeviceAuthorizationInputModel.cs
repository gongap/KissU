using KissU.IdentityServer.Quickstart.Consent;

namespace KissU.IdentityServer.Quickstart.Device
{
    /// <summary>
    /// DeviceAuthorizationInputModel.
    /// Implements the <see cref="KissU.IdentityServer.Quickstart.Consent.ConsentInputModel" />
    /// </summary>
    /// <seealso cref="KissU.IdentityServer.Quickstart.Consent.ConsentInputModel" />
    public class DeviceAuthorizationInputModel : ConsentInputModel
    {
        /// <summary>
        /// Gets or sets the user code.
        /// </summary>
        /// <value>The user code.</value>
        public string UserCode { get; set; }
    }
}