using Microsoft.Extensions.Configuration;

namespace KissU.Core.System.MongoProvider
{
    /// <summary>
    /// MongoConfig.
    /// </summary>
    public class MongoConfig
    {
        private static MongoConfig _configuration;
        private readonly IConfigurationRoot _config;

        /// <summary>
        /// Initializes a new instance of the <see cref="MongoConfig"/> class.
        /// </summary>
        /// <param name="Configuration">The configuration.</param>
        public MongoConfig(IConfigurationRoot Configuration)
        {
            _config = Configuration;
            _configuration = this;
        }

        /// <summary>
        /// Gets the default instance.
        /// </summary>
        public static MongoConfig DefaultInstance
        {
            get
            {
                return _configuration;
            }
        }
        /// <summary>
        /// Gets the mong connection string.
        /// </summary>
        public string MongConnectionString
        {
            get
            {
                return _config["MongConnectionString"];
            }
        }

    }
}
