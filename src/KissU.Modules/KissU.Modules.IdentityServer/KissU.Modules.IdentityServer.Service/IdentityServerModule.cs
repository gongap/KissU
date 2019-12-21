// <copyright file="IdentityServerModule.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using KissU.Core.CPlatform;
using KissU.Core.CPlatform.Module;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using KissU.Modules.IdentityServer.Data;
using KissU.Modules.IdentityServer.Data.UnitOfWorks.SqlServer;
using KissU.Modules.IdentityServer.Domain;
using Microsoft.Extensions.DependencyInjection;
using KissU.Util.Datas.SqlServer;

namespace KissU.Modules.IdentityServer.Service
{
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
                .GetSection(Consts.ConnectionStringSection).GetSection(Consts.ConnectionStringName).Value);
            builder.ContainerBuilder.Populate(services);
        }
    }
}
