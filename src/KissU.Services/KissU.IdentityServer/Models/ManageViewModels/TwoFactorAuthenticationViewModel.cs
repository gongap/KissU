namespace KissU.IdentityServer.Models.ManageViewModels
{
    /// <summary>
    /// Class TwoFactorAuthenticationViewModel.
    /// </summary>
    public class TwoFactorAuthenticationViewModel
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance has authenticator.
        /// </summary>
        /// <value><c>true</c> if this instance has authenticator; otherwise, <c>false</c>.</value>
        public bool HasAuthenticator { get; set; }

        /// <summary>
        /// Gets or sets the recovery codes left.
        /// </summary>
        /// <value>The recovery codes left.</value>
        public int RecoveryCodesLeft { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is2fa enabled].
        /// </summary>
        /// <value><c>true</c> if [is2fa enabled]; otherwise, <c>false</c>.</value>
        public bool Is2faEnabled { get; set; }
    }
}
