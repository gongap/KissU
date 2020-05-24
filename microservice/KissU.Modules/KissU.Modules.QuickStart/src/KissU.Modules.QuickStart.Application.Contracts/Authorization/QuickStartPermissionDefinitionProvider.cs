using KissU.Modules.QuickStart.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace KissU.Modules.QuickStart.Authorization
{
    public class QuickStartPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            //var moduleGroup = context.AddGroup(QuickStartPermissions.GroupName, L("Permission:QuickStart"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<QuickStartResource>(name);
        }
    }
}