using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;

namespace KissU.Modules.PermissionManagement.Domain.Identity
{
    public class UserPermissionManagementProvider : PermissionManagementProvider
    {
        public override string Name => UserPermissionValueProvider.ProviderName;

        public UserPermissionManagementProvider(
            IPermissionGrantRepository permissionGrantRepository, 
            IGuidGenerator guidGenerator,
            ICurrentTenant currentTenant) 
            : base(
                permissionGrantRepository,
                guidGenerator,
                currentTenant)
        {

        }
    }
}