// <copyright file="IdentityServerModule.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.IdentityServer.Service
{
    using Autofac.Extensions.DependencyInjection;
    using KissU.Modules.IdentityServer.Data.UnitOfWorks;
    using KissU.Modules.IdentityServer.Data.UnitOfWorks.SqlServer;
    using Microsoft.Extensions.DependencyInjection;
    using Surging.Core.CPlatform;
    using Surging.Core.CPlatform.Module;
    using Util.Datas.Ef;

    /// <summary>
    /// 扩展系统模块
    /// </summary>
    public class IdentityServerModule : BusinessModule
    {
        /// <summary>
        /// 注册第三方组件
        /// </summary>
        /// <param name="builder">容器构建器</param>
        protected override void RegisterBuilder(ContainerBuilderWrapper builder)
        {
            base.RegisterBuilder(builder);
            var services = new ServiceCollection();
            services.AddUnitOfWork<IIdentityServerUnitOfWork, IdentityServerUnitOfWork>(AppConfig
                .GetSection("ConnectionStrings").GetSection("DefaultConnection").Value);
            builder.ContainerBuilder.Populate(services);
        }
    }
}
