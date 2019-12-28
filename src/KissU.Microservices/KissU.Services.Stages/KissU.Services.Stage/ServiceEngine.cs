using KissU.Core.CPlatform.Engines.Implementation;
using KissU.Core.CPlatform.Utilities;

namespace KissU.Services.Stage
{
    /// <summary>
    /// 微服务引擎
    /// </summary>
    public class ServiceEngine : VirtualPathProviderServiceEngine
    {
        public ServiceEngine()
        {
            ModuleServiceLocationFormats = new[] {EnvironmentHelper.GetEnvironmentVariable("${ModulePath}|Modules")};
            ComponentServiceLocationFormats =
                new[] {EnvironmentHelper.GetEnvironmentVariable("${ComponentPath}|Components")};
            //ModuleServiceLocationFormats = new[] {
            //   ""
            //};
        }
    }
}