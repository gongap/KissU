using Autofac;
using KissU.Core.Datas.Transactions;
using KissU.Core.Datas.UnitOfWorks;
using KissU.Core.Dependency;
using KissU.Core.Sessions;
using KissU.Util.Datas.Tests.Integration.Commons.Domains.Repositories;
using KissU.Util.Datas.Tests.Integration.Ef.PgSql.Repositories;
using KissU.Util.Datas.Tests.Integration.Ef.PgSql.UnitOfWorks;

namespace KissU.Util.Datas.Tests.Integration.Commons.Datas.PgSql.Configs
{
    /// <summary>
    /// 依赖注入配置
    /// </summary>
    public class IocConfig : ConfigBase
    {
        /// <summary>
        /// 加载配置
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void Load(ContainerBuilder builder)
        {
            LoadInfrastructure(builder);
            LoadRepositories(builder);
        }

        /// <summary>
        /// 加载基础设施
        /// </summary>
        private void LoadInfrastructure(ContainerBuilder builder)
        {
            builder.AddScoped<IUnitOfWorkManager, UnitOfWorkManager>();
            builder.AddScoped<ITransactionActionManager, TransactionActionManager>();
            builder.AddScoped<IPgSqlUnitOfWork, PgSqlUnitOfWork>().PropertiesAutowired();
            builder.AddSingleton<ISession>(new Session(AppConfig.UserId));
        }

        /// <summary>
        /// 加载仓储
        /// </summary>
        private void LoadRepositories(ContainerBuilder builder)
        {
            builder.AddScoped<ICustomerRepository, CustomerRepository>();
        }
    }
}