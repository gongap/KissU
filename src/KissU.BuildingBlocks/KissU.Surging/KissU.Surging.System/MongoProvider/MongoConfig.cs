using Microsoft.Extensions.Configuration;

namespace KissU.Surging.System.MongoProvider
{
    /// <summary>
    /// MongoConfig.
    /// </summary>
    public class MongoConfig
    {
        private readonly IConfigurationRoot _config;

        /// <summary>
        /// Initializes a new instance of the <see cref="MongoConfig" /> class.
        /// </summary>
        /// <param name="Configuration">The configuration.</param>
        public MongoConfig(IConfigurationRoot Configuration)
        {
            _config = Configuration;
            DefaultInstance = this;
        }

        /// <summary>
        /// Gets the default instance.
        /// </summary>
        public static MongoConfig DefaultInstance { get; private set; }

        /// <summary>
        /// Gets the mong connection string.
        /// </summary>
        public string MongConnectionString => _config["MongConnectionString"];
    }
}