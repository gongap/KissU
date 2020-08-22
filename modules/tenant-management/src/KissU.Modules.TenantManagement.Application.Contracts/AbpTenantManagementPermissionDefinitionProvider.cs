using KissU.Modules.TenantManagement.Domain.Shared;
using KissU.Modules.TenantManagement.Domain.Shared.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace KissU.Modules.TenantManagement.Application.Contracts
{
    public class AbpTenantManagementPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var tenantManagementGroup = context.AddGroup(TenantManagementPermissions.GroupName, L("Permission:TenantManagement"));

            var tenantsPermission = tenantManagementGroup.AddPermission(TenantManagementPermissions.Tenants.Default, L("Permission:TenantManagement"), multiTenancySide: MultiTenancySides.Host);
            tenantsPermission.AddChild(TenantManagementPermissions.Tenants.Create, L("Permission:Create"), multiTenancySide: MultiTenancySides.Host);
            tenantsPermission.AddChild(TenantManagementPermissions.Tenants.Update, L("Permission:Edit"), multiTenancySide: MultiTenancySides.Host);
            tenantsPermission.AddChild(TenantManagementPermissions.Tenants.Delete, L("Permission:Delete"), multiTenancySide: MultiTenancySides.Host);
            tenantsPermission.AddChild(TenantManagementPermissions.Tenants.ManageFeatures, L("Permission:ManageFeatures"), multiTenancySide: MultiTenancySides.Host);
            tenantsPermission.AddChild(TenantManagementPermissions.Tenants.ManageConnectionStrings, L("Permission:ManageConnectionStrings"), multiTenancySide: MultiTenancySides.Host);
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AbpTenantManagementResource>(name);
        }
    }
}
