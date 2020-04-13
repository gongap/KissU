namespace KissU.Identity.Quickstart.Account
{
    /// <summary>
    /// LoggedOutViewModel.
    /// </summary>
    public class LoggedOutViewModel
    {
        /// <summary>
        /// Gets or sets the post logout redirect URI.
        /// </summary>
        /// <value>The post logout redirect URI.</value>
        public string PostLogoutRedirectUri { get; set; }
        /// <summary>
        /// Gets or sets the name of the client.
        /// </summary>
        /// <value>The name of the client.</value>
        public string ClientName { get; set; }
        /// <summary>
        /// Gets or sets the sign out iframe URL.
        /// </summary>
        /// <value>The sign out iframe URL.</value>
        public string SignOutIframeUrl { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [automatic redirect after sign out].
        /// </summary>
        /// <value><c>true</c> if [automatic redirect after sign out]; otherwise, <c>false</c>.</value>
        public bool AutomaticRedirectAfterSignOut { get; set; }

        /// <summary>
        /// Gets or sets the logout identifier.
        /// </summary>
        /// <value>The logout identifier.</value>
        public string LogoutId { get; set; }
        /// <summary>
        /// Gets a value indicating whether [trigger external signout].
        /// </summary>
        /// <value><c>true</c> if [trigger external signout]; otherwise, <c>false</c>.</value>
        public bool TriggerExternalSignout => ExternalAuthenticationScheme != null;
        /// <summary>
        /// Gets or sets the external authentication scheme.
        /// </summary>
        /// <value>The external authentication scheme.</value>
        public string ExternalAuthenticationScheme { get; set; }
    }
}