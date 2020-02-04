namespace KissU.Core.Stage.Configurations
{
    /// <summary>
    /// AccessSettingOption.
    /// </summary>
    public class AccessSettingOption
    {
        /// <summary>
        /// Gets or sets the white list.
        /// </summary>
        public string WhiteList { get; set; }

        /// <summary>
        /// Gets or sets the black list.
        /// </summary>
        public string BlackList { get; set; }

        /// <summary>
        /// Gets or sets the route path.
        /// </summary>
        public string RoutePath { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="AccessSettingOption"/> is enable.
        /// </summary>
        public bool Enable { get; set; }
    }
}
