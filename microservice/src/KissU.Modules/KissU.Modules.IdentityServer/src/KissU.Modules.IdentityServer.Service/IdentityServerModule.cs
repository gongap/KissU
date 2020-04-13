using Autofac.Extensions.DependencyInjection;
using KissU.Core.Module;
using KissU.Surging.CPlatform;
using KissU.Modules.IdentityServer.Data;
using KissU.Modules.IdentityServer.Data.UnitOfWorks.SqlServer;
using KissU.Modules.IdentityServer.Domain.UnitOfWorks;
using KissU.Modules.IdentityServer.Service.Extensions;
using KissU.Surging.KestrelHttpServer;
using KissU.Util.Dapper;
using KissU.Util.Ddd.Domain.Datas.Enums;
using KissU.Util.EntityFrameworkCore.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace KissU.Modules.IdentityServer.Service
{
    /// <summary>
    /// 扩展系统模块
    /// </summary>
    public class IdentityServerModule : KestrelHttpModule
    {
        /// <summary>
        /// 注册第三方组件
        /// </summary>
        /// <param name="builder">容器构建器</param>
        protected override void RegisterBuilder(ContainerBuilderWrapper builder)
        {
            base.RegisterBuilder(builder);
            var services = new ServiceCollection();
            services.AddUnitOfWork<IIdentityServerUnitOfWork, IdentityServerUnitOfWork>(AppConfig.GetSection(DbConstants.ConnectionStringSection).GetSection(DbConstants.ConnectionStringName).Value);
            services.AddSqlQuery<IdentityServerUnitOfWork>(config =>
            {
                config.DatabaseType = DatabaseType.SqlServer;
            });
           // services.AddIdentityServer4();
            builder.ContainerBuilder.Populate(services);
        }

        public override void Initialize(ApplicationInitializationContext context)
        {
            base.Initialize(context);
           // context.Builder.UseIdentityServer();
        }
    }
}