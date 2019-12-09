// <copyright file="ServiceEngine.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Microservices.Stage
{
    using Surging.Core.CPlatform.Engines.Implementation;
    using Surging.Core.CPlatform.Utilities;

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
