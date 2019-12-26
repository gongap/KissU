// <copyright file="GreatWallModule.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using KissU.Core.CPlatform;
using KissU.Core.CPlatform.Module;
using Autofac.Extensions.DependencyInjection;
using KissU.Modules.GreatWall.Application.Extensions;
using KissU.Modules.GreatWall.Data;
using KissU.Modules.GreatWall.Data.UnitOfWorks.SqlServer;
using Microsoft.Extensions.DependencyInjection;
using KissU.Util.Datas.SqlServer;

namespace KissU.Modules.GreatWall.Service
{
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
