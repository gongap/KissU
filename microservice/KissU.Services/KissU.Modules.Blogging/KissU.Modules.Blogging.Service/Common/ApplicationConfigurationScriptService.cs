using System.Text;
using System.Threading.Tasks;
using KissU.Dependency;
using KissU.Modules.Application.Configurations;
using KissU.Modules.Application.Service.Contracts;
using KissU.Surging.ProxyGenerator;
using Volo.Abp.Json;

namespace KissU.Modules.Application.Service.Implements
{
    [ModuleName("Bloging")]
    public class BlogingApplicationConfigurationScriptService : AbpApplicationConfigurationScriptService
    {
        protected BlogingApplicationConfigurationScriptService(IAbpApplicationConfigurationAppService configurationAppService, IJsonSerializer jsonSerializer) : base(configurationAppService, jsonSerializer)
        {
        }
    }
}