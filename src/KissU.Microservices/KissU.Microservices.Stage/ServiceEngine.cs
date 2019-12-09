using Surging.Core.CPlatform.Engines.Implementation;
using Surging.Core.CPlatform.Utilities;

namespace KissU.Microservices.Stage
{
    /// <summary>
    /// 微服务引擎
    /// </summary>
    public class ServiceEngine: VirtualPathProviderServiceEngine
    {
        public ServiceEngine()
        {
            ModuleServiceLocationFormats = new[] {
                EnvironmentHelper.GetEnvironmentVariable("${ModulePath1}|Modules"),
            };
            ComponentServiceLocationFormats  = new[] {
                 EnvironmentHelper.GetEnvironmentVariable("${ComponentPath1}|Components"),
            };
            //ModuleServiceLocationFormats = new[] {
            //   ""
            //};
        }
    }
}
