using Autofac;
using Util.Datas.Dapper;
using Util.Datas.Dapper.SqlServer;
using Util.Datas.Sql;
using Util.Datas.Sql.Matedatas;
using Util.Datas.Transactions;
using Util.Datas.UnitOfWorks;
using Util.Dependency;
using Util.Sessions;
using KissU.Data;
using KissU.Data.Repositories.Systems;
using KissU.Domain.Systems.Repositories;
using KissU.IntegrationTest.Ef.SqlServer.UnitOfWorks;
using KissU.Service.Abstractions.Systems;
using KissU.Service.Implements.Systems;
using Util.Reflections;

namespace KissU.IntegrationTest.Commons.Datas.SqlServer.Configs
{
    /// <summary>
    /// 依赖注入配置
    /// </summary>
    public class IocConfig : ConfigBase {
        /// <summary>
        /// 加载配置
        /// </summary>
        protected override void Load( ContainerBuilder builder ) {
            LoadInfrastructure( builder );
            LoadRepositories( builder );
        }

        /// <summary>
        /// 加载基础设施
        /// </summary>
        private void LoadInfrastructure( ContainerBuilder builder ) {
            builder.AddSingleton<ISession>( new Session( AppConfig.UserId ) );
            builder.AddScoped<IUnitOfWorkManager, UnitOfWorkManager>();
            builder.AddScoped<ITransactionActionManager, TransactionActionManager>();
            builder.RegisterType<KissUUnitOfWork>().AsSelf().InstancePerLifetimeScope().PropertiesAutowired();
            builder.Register( t => t.Resolve<KissUUnitOfWork>() ).As<IKissUUnitOfWork>().InstancePerLifetimeScope().PropertiesAutowired();
            builder.Register( t => t.Resolve<KissUUnitOfWork>() ).As<IDatabase>().InstancePerLifetimeScope().PropertiesAutowired();
            builder.Register( t => t.Resolve<KissUUnitOfWork>() ).As<IEntityMatedata>().InstancePerLifetimeScope().PropertiesAutowired();
            builder.AddScoped<ISqlQuery, SqlQuery>();
            builder.AddScoped<ISqlBuilder, SqlServerBuilder>();
        }

        /// <summary>
        /// 加载仓储
        /// </summary>
        private void LoadRepositories( ContainerBuilder builder ) {
            builder.AddScoped<IApplicationRepository, ApplicationRepository>();
            builder.AddScoped<IMenuRepository, MenuRepository>();
            builder.AddScoped<IRoleRepository, RoleRepository>();
            builder.AddScoped<IApplicationService, ApplicationService>();
            builder.AddScoped<IMenuService, MenuService>();
            builder.AddScoped<IRoleService, RoleService>();
        }
    }
}