using Autofac.Extensions.DependencyInjection;
using KissU.Core.Module;
using KissU.Surging.CPlatform;
using KissU.Modules.GreatWall.Application.Extensions;
using KissU.Modules.GreatWall.Data;
using KissU.Modules.GreatWall.Data.UnitOfWorks.SqlServer;
using KissU.Modules.GreatWall.Domain.UnitOfWorks;
using KissU.Util.Dapper;
using KissU.Util.Ddd.Data.Enums;
using KissU.Util.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddUnitOfWork<IGreatWallUnitOfWork, GreatWallUnitOfWork>(AppConfig
                .GetSection(DbConstants.ConnectionStringSection).GetSection(DbConstants.ConnectionStringName).Value);
            services.AddSqlQuery<GreatWallUnitOfWork>(config =>
            {
                config.DatabaseType = DatabaseType.SqlServer;
            });
            services.AddAspNetIdentityCore(options =>
            {
                options.Password.MinLength = 6;
                options.Password.NonAlphanumeric = true;
                options.Password.Uppercase = true;
                options.Password.Digit = true;
            });
            builder.ContainerBuilder.Populate(services);
        }
    }
}