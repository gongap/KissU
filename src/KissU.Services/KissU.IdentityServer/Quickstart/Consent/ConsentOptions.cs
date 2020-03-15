namespace KissU.IdentityServer.Quickstart.Consent
{
    /// <summary>
    /// ConsentOptions.
    /// </summary>
    public class ConsentOptions
    {
        /// <summary>
        /// The enable offline access
        /// </summary>
        public static bool EnableOfflineAccess = true;
        /// <summary>
        /// The offline access display name
        /// </summary>
        public static string OfflineAccessDisplayName = "Offline Access";
        /// <summary>
        /// The offline access description
        /// </summary>
        public static string OfflineAccessDescription = "Access to your applications and resources, even when you are offline";

        /// <summary>
        /// The must choose one error message
        /// </summary>
        public static readonly string MustChooseOneErrorMessage = "You must pick at least one permission";
        /// <summary>
        /// The invalid selection error message
        /// </summary>
        public static readonly string InvalidSelectionErrorMessage = "Invalid selection";
    }
}
