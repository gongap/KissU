using Com.Ctrip.Framework.Apollo.Enums;

namespace KissU.Surging.Configuration.Apollo.Configurations
{
    /// <summary>
    /// ConfigFileFormatMethods.
    /// </summary>
    public static class ConfigFileFormatMethods
    {
        /// <summary>
        /// Gets the string.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <returns>System.String.</returns>
        public static string GetString(this ConfigFileFormat format)
        {
            return format switch
                {
                ConfigFileFormat.Properties => "properties",
                ConfigFileFormat.Xml => "xml",
                ConfigFileFormat.Json => "json",
                ConfigFileFormat.Yml => "yml",
                ConfigFileFormat.Yaml => "yaml",
                ConfigFileFormat.Txt => "txt",
                _ => "unknown",
                };
        }
    }
}