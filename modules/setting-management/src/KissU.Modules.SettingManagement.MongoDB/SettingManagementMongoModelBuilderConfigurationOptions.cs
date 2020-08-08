using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace KissU.Modules.SettingManagement.MongoDB
{
    public class SettingManagementMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public SettingManagementMongoModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "")
            : base(tablePrefix)
        {
        }
    }
}