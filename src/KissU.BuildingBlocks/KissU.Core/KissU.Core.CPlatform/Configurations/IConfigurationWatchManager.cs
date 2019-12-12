using KissU.Core.CPlatform.Configurations.Watch;

namespace KissU.Core.CPlatform.Configurations
{
    public  interface IConfigurationWatchManager
    {
        void Register(ConfigurationWatch watch);
    }
}
