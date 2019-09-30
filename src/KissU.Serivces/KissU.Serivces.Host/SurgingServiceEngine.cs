using Surging.Core.CPlatform.Engines.Implementation;
using Surging.Core.CPlatform.Utilities;

namespace KissU.Services.Host
{
    /// <summary>
    /// 微服务引擎
    /// </summary>
    public class SurgingServiceEngine: VirtualPathProviderServiceEngine
    {
        public SurgingServiceEngine()
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
