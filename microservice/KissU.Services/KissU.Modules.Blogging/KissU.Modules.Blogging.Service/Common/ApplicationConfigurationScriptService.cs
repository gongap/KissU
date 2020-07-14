using KissU.Dependency;
using KissU.Modules.Application.Configurations;
using KissU.Modules.Application.Service.Implements;
using Volo.Abp.Json;

namespace KissU.Modules.Blogging.Service.Common
{
    [ModuleName("Bloging")]
    public class BlogingApplicationConfigurationScriptService : AbpApplicationConfigurationScriptService
    {
        protected BlogingApplicationConfigurationScriptService(IAbpApplicationConfigurationAppService configurationAppService, IJsonSerializer jsonSerializer) : base(configurationAppService, jsonSerializer)
        {
        }
    }
}