using Autofac;
using KissU.Util.Datas.Tests.Integration.Commons.Domains.Repositories;
using KissU.Util.Datas.Tests.Integration.PgSql.Ef.Repositories;
using KissU.Util.Datas.Tests.Integration.PgSql.Ef.UnitOfWorks;
using KissU.Util.Datas.Transactions;
using KissU.Util.Datas.UnitOfWorks;
using KissU.Util.Dependency;
using KissU.Util.Sessions;

namespace KissU.Util.Datas.Tests.Integration.Commons.Datas.PgSql.Configs {
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
            builder.AddScoped<IUnitOfWorkManager, UnitOfWorkManager>();
            builder.AddScoped<ITransactionActionManager, TransactionActionManager>();
            builder.AddScoped<IPgSqlUnitOfWork, PgSqlUnitOfWork>().PropertiesAutowired();
            builder.AddSingleton<ISession>( new Session( AppConfig.UserId ) );
        }

        /// <summary>
        /// 加载仓储
        /// </summary>
        private void LoadRepositories( ContainerBuilder builder ) {
            builder.AddScoped<ICustomerRepository, CustomerRepository>();
        }
    }
}
