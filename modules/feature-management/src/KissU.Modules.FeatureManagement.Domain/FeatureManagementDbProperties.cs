using Volo.Abp.Data;

namespace KissU.Modules.FeatureManagement.Domain
{
    public static class FeatureManagementDbProperties
    {
        public static string DbTablePrefix { get; set; } = AbpCommonDbProperties.DbTablePrefix;

        public static string DbSchema { get; set; } = AbpCommonDbProperties.DbSchema;

        public const string ConnectionStringName = "AbpFeatureManagement";
    }
}
