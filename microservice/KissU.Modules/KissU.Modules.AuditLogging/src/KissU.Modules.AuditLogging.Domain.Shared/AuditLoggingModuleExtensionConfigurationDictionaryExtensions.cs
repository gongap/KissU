using System;
using Volo.Abp.ObjectExtending.Modularity;

namespace KissU.Modules.AuditLogging.Domain.Shared
{
    public static class AuditLoggingModuleExtensionConfigurationDictionaryExtensions
    {
        public static ModuleExtensionConfigurationDictionary ConfigureAuditLogging(
            this ModuleExtensionConfigurationDictionary modules,
            Action<AuditLoggingModuleExtensionConfiguration> configureAction)
        {
            return modules.ConfigureModule(
                AuditLoggingModuleExtensionConsts.ModuleName,
                configureAction
            );
        }
    }
}