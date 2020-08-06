using System.Text;
using System.Threading.Tasks;
using KissU.Modules.Application.Configurations;
using KissU.Modules.Configuration.Service.Contracts;
using KissU.ProxyGenerator;
using Volo.Abp.Json;

namespace KissU.Modules.Configuration.Service.Implements
{
    public class AbpApplicationConfigurationScriptService : ProxyServiceBase, IAbpApplicationConfigurationScriptService
    {
        private readonly IAbpApplicationConfigurationAppService _configurationAppService;
        private readonly IJsonSerializer _jsonSerializer;

        public AbpApplicationConfigurationScriptService(
            IAbpApplicationConfigurationAppService configurationAppService,
            IJsonSerializer jsonSerializer)
        {
            _configurationAppService = configurationAppService;
            _jsonSerializer = jsonSerializer;
        }

        public async Task<string> Get()
        {
            return CreateAbpExtendScript(await _configurationAppService.GetAsync());
        }

        private string CreateAbpExtendScript(ApplicationConfigurationDto config)
        {
            var script = new StringBuilder();

            script.AppendLine("(function(){");
            script.AppendLine();
            script.AppendLine($"$.extend(true, abp, {_jsonSerializer.Serialize(config, indented: true)})");
            script.AppendLine();
            script.AppendLine("abp.event.trigger('abp.configurationInitialized');");
            script.AppendLine();
            script.Append("})();");

            return script.ToString();
        }
    }
}