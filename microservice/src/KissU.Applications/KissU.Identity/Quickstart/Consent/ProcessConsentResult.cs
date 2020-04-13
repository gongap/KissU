namespace KissU.Identity.Quickstart.Consent
{
    /// <summary>
    /// ProcessConsentResult.
    /// </summary>
    public class ProcessConsentResult
    {
        /// <summary>
        /// Gets a value indicating whether this instance is redirect.
        /// </summary>
        /// <value><c>true</c> if this instance is redirect; otherwise, <c>false</c>.</value>
        public bool IsRedirect => RedirectUri != null;
        /// <summary>
        /// Gets or sets the redirect URI.
        /// </summary>
        /// <value>The redirect URI.</value>
        public string RedirectUri { get; set; }
        /// <summary>
        /// Gets or sets the client identifier.
        /// </summary>
        /// <value>The client identifier.</value>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets a value indicating whether [show view].
        /// </summary>
        /// <value><c>true</c> if [show view]; otherwise, <c>false</c>.</value>
        public bool ShowView => ViewModel != null;
        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        /// <value>The view model.</value>
        public ConsentViewModel ViewModel { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance has validation error.
        /// </summary>
        /// <value><c>true</c> if this instance has validation error; otherwise, <c>false</c>.</value>
        public bool HasValidationError => ValidationError != null;
        /// <summary>
        /// Gets or sets the validation error.
        /// </summary>
        /// <value>The validation error.</value>
        public string ValidationError { get; set; }
    }
}
