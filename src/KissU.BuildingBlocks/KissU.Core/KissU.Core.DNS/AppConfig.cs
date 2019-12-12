using KissU.Core.DNS.Configurations;
using Microsoft.Extensions.Configuration;

namespace KissU.Core.DNS
{
    public static  class AppConfig
    {
        public static IConfigurationRoot Configuration { get; set; }

        public static DnsOption DnsOption { get; set; }
    }
}
