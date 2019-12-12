﻿// <copyright file="GreatWallModule.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using KissU.Core.CPlatform;
using KissU.Core.CPlatform.Module;

namespace KissU.Modules.GreatWall.Service
{
    using Autofac.Extensions.DependencyInjection;
    using KissU.Modules.GreatWall.Data;
    using KissU.Modules.GreatWall.Data.UnitOfWorks.SqlServer;
    using KissU.Modules.GreatWall.Service.Extensions;
    using Microsoft.Extensions.DependencyInjection;
    using Util.Datas.Ef;

    /// <summary>
    /// 扩展系统模块
    /// </summary>
    public class GreatWallModule : BusinessModule
    {
        /// <summary>
        /// 注册第三方组件
        /// </summary>
        /// <param name="builder">容器构建器</param>
        protected override void RegisterBuilder(ContainerBuilderWrapper builder)
        {
            base.RegisterBuilder(builder);
            var services = new ServiceCollection();
            services.AddUnitOfWork<IGreatWallUnitOfWork, GreatWallUnitOfWork>(AppConfig.GetSection("ConnectionStrings")
                .GetSection("DefaultConnection").Value);
            services.AddPermission(t => { t.Lockout.MaxFailedAccessAttempts = 2; });
            builder.ContainerBuilder.Populate(services);
        }
    }
}
