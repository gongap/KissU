namespace KissU.AspNetCore.Stage.Configurations
{
    /// <summary>
    /// AuthServerOption.
    /// </summary>
    public class AuthServerOption
    {
        /// <summary>
        /// Gets or sets the white list.
        /// </summary>
        public string Authority { get; set; }

        /// <summary>
        /// Gets or sets the white list.
        /// </summary>
        public string ApiName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="AuthServerOption"/> is HTTPS.
        /// </summary>
        public bool Https { get; set; } = false;
    }
}