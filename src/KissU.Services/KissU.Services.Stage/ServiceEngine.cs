﻿using KissU.Core.CPlatform.Engines.Implementation;
using KissU.Core.CPlatform.Utilities;

namespace KissU.Services.Stage
{
    /// <summary>
    /// 微服务引擎虚拟路径提供程序
    /// </summary>
    public class ServiceEngine : VirtualPathProviderServiceEngine
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceEngine"/> class.
        /// </summary>
        public ServiceEngine()
        {
            ModuleServiceLocationFormats = new[] { EnvironmentHelper.GetEnvironmentVariable("${ModulePath}|Modules") };
            ComponentServiceLocationFormats = new[] { EnvironmentHelper.GetEnvironmentVariable("${ComponentPath}|Components") };
        }
    }
}