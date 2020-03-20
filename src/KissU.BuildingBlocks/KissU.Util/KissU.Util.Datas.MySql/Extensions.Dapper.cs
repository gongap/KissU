using System;
using Dapper;
using KissU.Core.Datas.Enums;
using KissU.Core.Datas.Sql;
using KissU.Core.Datas.Sql.Configs;
using KissU.Core.Datas.Sql.Matedatas;
using KissU.Util.Datas.Dapper;
using KissU.Util.Datas.Dapper.Handlers;
using KissU.Util.Datas.MySql.Dapper;
using KissU.Util.Datas.Sql;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace KissU.Util.Datas.MySql
{
    /// <summary>
    /// 服务扩展
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// 注册Sql查询服务
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="action">Sql查询配置</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection AddSqlQuery(this IServiceCollection services, Action<SqlOptions> action = null)
        {
            return AddSqlQuery(services, action, null, null);
        }

        /// <summary>
        /// 注册Sql查询服务
        /// </summary>
        /// <typeparam name="TDatabase">IDatabase实现类型，提供数据库连接</typeparam>
        /// <param name="services">服务集合</param>
        /// <param name="action">Sql查询配置</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection AddSqlQuery<TDatabase>(this IServiceCollection services,
            Action<SqlOptions> action = null)
            where TDatabase : class, IDatabase
        {
            return AddSqlQuery(services, action, typeof(TDatabase), null);
        }

        /// <summary>
        /// 注册Sql查询服务
        /// </summary>
        /// <typeparam name="TDatabase">IDatabase实现类型，提供数据库连接</typeparam>
        /// <typeparam name="TEntityMatedata">IEntityMatedata实现类型,提供实体元数据解析</typeparam>
        /// <param name="services">服务集合</param>
        /// <param name="action">Sql查询配置</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection AddSqlQuery<TDatabase, TEntityMatedata>(this IServiceCollection services,
            Action<SqlOptions> action = null)
            where TDatabase : class, IDatabase
            where TEntityMatedata : class, IEntityMatedata
        {
            return AddSqlQuery(services, action, typeof(TDatabase), typeof(TEntityMatedata));
        }

        /// <summary>
        /// 注册Sql查询服务
        /// </summary>
        private static IServiceCollection AddSqlQuery(IServiceCollection services, Action<SqlOptions> action,
            Type database, Type entityMatedata)
        {
            var config = new SqlOptions();
            if (action != null)
            {
                action.Invoke(config);
                services.Configure(action);
            }

            if (entityMatedata != null)
                services.TryAddScoped(typeof(IEntityMatedata), t => t.GetService(entityMatedata));
            if (database != null)
            {
                services.TryAddScoped(database);
                services.TryAddScoped(typeof(IDatabase), t => t.GetService(database));
            }

            services.TryAddTransient<ISqlQuery, SqlQuery>();
            services.TryAddScoped<ITableDatabase, DefaultTableDatabase>();
            AddSqlBuilder(services, config);
            RegisterTypeHandlers(config);
            return services;
        }

        /// <summary>
        /// 配置Sql生成器
        /// </summary>
        private static void AddSqlBuilder(IServiceCollection services, SqlOptions config)
        {
            services.TryAddTransient<ISqlBuilder, MySqlBuilder>();
        }

        /// <summary>
        /// 注册类型处理器
        /// </summary>
        private static void RegisterTypeHandlers(SqlOptions config)
        {
            SqlMapper.AddTypeHandler(typeof(string), new StringTypeHandler());
            if (config.DatabaseType == DatabaseType.Oracle)
                SqlMapper.AddTypeHandler(new GuidTypeHandler());
        }
    }
}