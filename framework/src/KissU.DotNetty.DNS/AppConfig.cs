﻿using KissU.DotNetty.DNS.Configurations;
using Microsoft.Extensions.Configuration;

namespace KissU.DotNetty.DNS
{
    /// <summary>
    /// AppConfig.
    /// </summary>
    public static class AppConfig
    {
        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        public static IConfigurationRoot Configuration { get; set; }

        /// <summary>
        /// Gets or sets the DNS option.
        /// </summary>
        public static DnsOption DnsOption { get; set; }
    }
}