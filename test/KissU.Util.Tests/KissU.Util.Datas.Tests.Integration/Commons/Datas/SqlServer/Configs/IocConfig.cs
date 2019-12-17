using Autofac;
using KissU.Util.Datas.Dapper;
using KissU.Util.Datas.SqlServer.Dapper;
using KissU.Util.Datas.Sql;
using KissU.Util.Datas.Sql.Matedatas;
using KissU.Util.Datas.Tests.Integration.Commons.Domains.Repositories;
using KissU.Util.Datas.Tests.Integration.SqlServer.Ef.Repositories;
using KissU.Util.Datas.Tests.Integration.SqlServer.Ef.Stores;
using KissU.Util.Datas.Tests.Integration.SqlServer.Ef.UnitOfWorks;
using KissU.Util.Datas.Transactions;
using KissU.Util.Datas.UnitOfWorks;
using KissU.Util.Dependency;
using KissU.Util.Sessions;

namespace KissU.Util.Datas.Tests.Integration.Commons.Datas.SqlServer.Configs {
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
            builder.RegisterType<SqlServerUnitOfWork>().AsSelf().InstancePerLifetimeScope().PropertiesAutowired();
            builder.Register( t => t.Resolve<SqlServerUnitOfWork>() ).As<ISqlServerUnitOfWork>().InstancePerLifetimeScope().PropertiesAutowired();
            builder.Register( t => t.Resolve<SqlServerUnitOfWork>() ).As<IDatabase>().InstancePerLifetimeScope().PropertiesAutowired();
            builder.Register( t => t.Resolve<SqlServerUnitOfWork>() ).As<IEntityMatedata>().InstancePerLifetimeScope().PropertiesAutowired();
            builder.AddScoped<ISqlQuery, SqlQuery>();
            builder.AddScoped<ISqlBuilder, SqlServerBuilder>();
            builder.AddScoped<IProductPoStore, ProductPoStore>();
        }

        /// <summary>
        /// 加载仓储
        /// </summary>
        private void LoadRepositories( ContainerBuilder builder ) {
            builder.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.AddScoped<IOrderRepository, OrderRepository>();
            builder.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
