using Volo.Abp.Data;

namespace KissU.Modules.TenantManagement.Domain
{
    public static class AbpTenantManagementDbProperties
    {
        public static string DbTablePrefix { get; set; } = AbpCommonDbProperties.DbTablePrefix;

        public static string DbSchema { get; set; } = AbpCommonDbProperties.DbSchema;

        public const string ConnectionStringName = "AbpTenantManagement";
    }
}
