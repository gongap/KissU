namespace KissU.Identity.Quickstart.Consent
{
    /// <summary>
    /// ScopeViewModel.
    /// </summary>
    public class ScopeViewModel
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        /// <value>The display name.</value>
        public string DisplayName { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ScopeViewModel"/> is emphasize.
        /// </summary>
        /// <value><c>true</c> if emphasize; otherwise, <c>false</c>.</value>
        public bool Emphasize { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ScopeViewModel"/> is required.
        /// </summary>
        /// <value><c>true</c> if required; otherwise, <c>false</c>.</value>
        public bool Required { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ScopeViewModel"/> is checked.
        /// </summary>
        /// <value><c>true</c> if checked; otherwise, <c>false</c>.</value>
        public bool Checked { get; set; }
    }
}
