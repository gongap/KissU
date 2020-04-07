using System;
using KissU.Core.Datas.UnitOfWorks;
using KissU.Util.Ddd.Domain.Datas.Enums;
using KissU.Util.EntityFrameworkCore.Configs;
using KissU.Util.EntityFrameworkCore.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace KissU.Util.EntityFrameworkCore.PgSql
{
    /// <summary>
    /// 服务扩展
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// 注册工作单元服务
        /// </summary>
        /// <typeparam name="TService">工作单元接口类型</typeparam>
        /// <typeparam name="TImplementation">工作单元实现类型</typeparam>
        /// <param name="services">服务集合</param>
        /// <param name="configAction">配置操作</param>
        /// <param name="efConfigAction">Ef配置操作</param>
        /// <param name="configuration">配置</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection AddUnitOfWork<TService, TImplementation>(this IServiceCollection services,
            Action<DbContextOptionsBuilder> configAction, Action<EfConfig> efConfigAction = null,
            IConfiguration configuration = null)
            where TService : class, IUnitOfWork
            where TImplementation : UnitOfWorkBase, TService
        {
            services.AddDbContext<TImplementation>(configAction);
            var efConfig = new EfConfig();
            if (efConfigAction != null)
            {
                services.Configure(efConfigAction);
                efConfigAction.Invoke(efConfig);
            }

            if (configuration != null)
                services.Configure<EfConfig>(configuration);
            services.TryAddScoped<TService>(t => t.GetService<TImplementation>());
            services.TryAddScoped<IUnitOfWork>(t => t.GetService<TImplementation>());
            //services.AddSqlQuery<TImplementation, TImplementation>(config =>
            //{
            //    config.DatabaseType = GetDbType<TImplementation>();
            //    config.IsClearAfterExecution = efConfig.SqlQuery.IsClearAfterExecution;
            //});
            return services;
        }

        /// <summary>
        /// 获取数据库类型
        /// </summary>
        private static DatabaseType GetDbType<TUnitOfWork>()
        {
            return DatabaseType.PgSql;
        }

        /// <summary>
        /// 注册工作单元服务
        /// </summary>
        /// <typeparam name="TService">工作单元接口类型</typeparam>
        /// <typeparam name="TImplementation">工作单元实现类型</typeparam>
        /// <param name="services">服务集合</param>
        /// <param name="connection">连接字符串</param>
        /// <param name="level">Ef日志级别</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection AddUnitOfWork<TService, TImplementation>(this IServiceCollection services,
            string connection, EfLogLevel level = EfLogLevel.Sql)
            where TService : class, IUnitOfWork
            where TImplementation : UnitOfWorkBase, TService
        {
            return AddUnitOfWork<TService, TImplementation>(services,
                builder => { ConfigConnection<TImplementation>(builder, connection); },
                config => config.EfLogLevel = level);
        }

        /// <summary>
        /// 配置连接字符串
        /// </summary>
        private static void ConfigConnection<TImplementation>(DbContextOptionsBuilder builder, string connection)
            where TImplementation : UnitOfWorkBase
        {
            builder.UseNpgsql(connection);
        }

        /// <summary>
        /// 注册工作单元服务
        /// </summary>
        /// <typeparam name="TService">工作单元接口类型</typeparam>
        /// <typeparam name="TImplementation">工作单元实现类型</typeparam>
        /// <param name="services">服务集合</param>
        /// <param name="connection">连接字符串</param>
        /// <param name="efConfigAction">Ef配置操作</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection AddUnitOfWork<TService, TImplementation>(this IServiceCollection services,
            string connection, Action<EfConfig> efConfigAction)
            where TService : class, IUnitOfWork
            where TImplementation : UnitOfWorkBase, TService
        {
            return AddUnitOfWork<TService, TImplementation>(services,
                builder => { ConfigConnection<TImplementation>(builder, connection); }, efConfigAction);
        }

        /// <summary>
        /// 注册工作单元服务
        /// </summary>
        /// <typeparam name="TService">工作单元接口类型</typeparam>
        /// <typeparam name="TImplementation">工作单元实现类型</typeparam>
        /// <param name="services">服务集合</param>
        /// <param name="connection">连接字符串</param>
        /// <param name="configuration">配置</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection AddUnitOfWork<TService, TImplementation>(this IServiceCollection services,
            string connection, IConfiguration configuration)
            where TService : class, IUnitOfWork
            where TImplementation : UnitOfWorkBase, TService
        {
            return AddUnitOfWork<TService, TImplementation>(services,
                builder => { ConfigConnection<TImplementation>(builder, connection); }, null, configuration);
        }
    }
}