using Autofac.Extensions.DependencyInjection;
using KissU.Core.Module;
using KissU.Surging.CPlatform;
using KissU.Modules.IdentityServer.Data;
using KissU.Modules.IdentityServer.Data.UnitOfWorks.SqlServer;
using KissU.Modules.IdentityServer.Domain.UnitOfWorks;
using KissU.Util.Dapper;
using KissU.Util.Ddd.Data.Enums;
using KissU.Util.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.DependencyInjection;

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
                .GetSection(DbConstants.ConnectionStringSection).GetSection(DbConstants.ConnectionStringName).Value);
            services.AddSqlQuery<IdentityServerUnitOfWork>(config =>
            {
                config.DatabaseType = DatabaseType.SqlServer;
            });
            builder.ContainerBuilder.Populate(services);
        }
    }
}