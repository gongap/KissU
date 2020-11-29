﻿using KissU.Modularity;
using Localization.Resources.AbpUi;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.PermissionManagement.Localization;
using Volo.Abp.UI;

namespace KissU.Modules.PermissionManagement.Service.Contracts
{
    [DependsOn(
        typeof(AbpPermissionManagementApplicationContractsModule),
        typeof(AbpUiModule)
    )]
    public class PermissionManagementServiceContractsModule : AbpBusinessModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<AbpPermissionManagementResource>()
                    .AddBaseTypes(
                        typeof(AbpUiResource)
                    );
            });
        }
    }
}