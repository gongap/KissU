namespace KissU.Services.Identity.Quickstart.Account
{
    /// <summary>
    /// LogoutViewModel.
    /// Implements the <see cref="LogoutInputModel" />
    /// </summary>
    /// <seealso cref="LogoutInputModel" />
    public class LogoutViewModel : LogoutInputModel
    {
        /// <summary>
        /// Gets or sets a value indicating whether [show logout prompt].
        /// </summary>
        /// <value><c>true</c> if [show logout prompt]; otherwise, <c>false</c>.</value>
        public bool ShowLogoutPrompt { get; set; } = true;
    }
}
