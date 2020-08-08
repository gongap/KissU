using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace KissU.Modules.TenantManagement.EntityFrameworkCore
{
    public class AbpTenantManagementModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public AbpTenantManagementModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix,
            [CanBeNull] string schema)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}