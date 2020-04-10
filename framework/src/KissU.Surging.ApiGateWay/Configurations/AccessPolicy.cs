namespace KissU.Surging.ApiGateWay.Configurations
{
    /// <summary>
    /// AccessPolicy.
    /// </summary>
    public class AccessPolicy
    {
        /// <summary>
        /// Gets or sets the origins.
        /// </summary>
        public string[] Origins { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [allow any header].
        /// </summary>
        public bool AllowAnyHeader { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [allow any method].
        /// </summary>
        public bool AllowAnyMethod { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [allow any origin].
        /// </summary>
        public bool AllowAnyOrigin { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [allow credentials].
        /// </summary>
        public bool AllowCredentials { get; set; }
    }
}