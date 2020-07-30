using KissU.Helpers;

namespace KissU.Engines.Implementation
{
    /// <summary>
    /// 微服务引擎虚拟路径提供程序
    /// </summary>
    public class DefaultVirtualPathProviderServiceEngine : VirtualPathProviderServiceEngine
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultVirtualPathProviderServiceEngine"/> class.
        /// </summary>
        public DefaultVirtualPathProviderServiceEngine()
        {
            ModuleServiceLocationFormats = new[] { EnvironmentHelper.GetEnvironmentVariable("${ModulePath}|Modules") };
            ComponentServiceLocationFormats = new[] { EnvironmentHelper.GetEnvironmentVariable("${ComponentPath}|Components") };
        }
    }
}