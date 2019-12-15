// <copyright file="ThemeModule.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using KissU.Core.CPlatform;
using KissU.Core.CPlatform.Module;

namespace KissU.Modules.Theme.Service
{
    using Autofac.Extensions.DependencyInjection;
    using KissU.Modules.Theme.Data;
    using KissU.Modules.Theme.Data.UnitOfWorks.SqlServer;
    using Microsoft.Extensions.DependencyInjection;
    using Util.Datas.Ef;

    /// <summary>
    /// 扩展系统模块
    /// </summary>
    public class ThemeModule : BusinessModule
    {
        /// <summary>
        /// 注册第三方组件
        /// </summary>
        /// <param name="builder">容器构建器</param>
        protected override void RegisterBuilder(ContainerBuilderWrapper builder)
        {
            base.RegisterBuilder(builder);
            var services = new ServiceCollection();
            services.AddUnitOfWork<IThemeUnitOfWork, ThemeUnitOfWork>(AppConfig.GetSection("ConnectionStrings")
                .GetSection("DefaultConnection").Value);
            builder.ContainerBuilder.Populate(services);
        }
    }
}
