using Volo.Abp.Collections;

namespace KissU.Modules.SettingManagement.Domain
{
    public class SettingManagementOptions
    {
        public ITypeList<ISettingManagementProvider> Providers { get; }

        public SettingManagementOptions()
        {
            Providers = new TypeList<ISettingManagementProvider>();
        }
    }
}
