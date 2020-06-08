using System;
using KissU.Modules.SettingManagement.Domain;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace KissU.Modules.SettingManagement.MongoDB
{
    public static class SettingManagementMongoDbContextExtensions
    {
        public static void ConfigureSettingManagement(
            this IMongoModelBuilder builder,
            Action<SettingManagementMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new SettingManagementMongoModelBuilderConfigurationOptions(
                AbpSettingManagementDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);

            builder.Entity<Setting>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Settings";
            });
        }
    }
}