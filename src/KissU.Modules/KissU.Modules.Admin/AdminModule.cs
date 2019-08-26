using Autofac.Extensions.DependencyInjection;
using KissU.Modules.Admin.Data;
using KissU.Modules.Admin.Data.UnitOfWorks.SqlServer;
using Microsoft.Extensions.DependencyInjection;
using Surging.Core.CPlatform;
using Surging.Core.CPlatform.Module;
using Surging.Core.ProxyGenerator;
using Surging.Core.System.Intercept;
using Util.Datas.Ef;

namespace KissU.Modules.Admin
{
    /// <summary>
    /// 扩展系统模块
    /// </summary>
    public class AdminModule : SystemModule
    {
        /// <summary>
        /// 注册第三方组件
        /// </summary>
        /// <param name="builder">容器构建器</param>
        protected override void RegisterBuilder(ContainerBuilderWrapper builder)
        {
            base.RegisterBuilder(builder);
            var services = new ServiceCollection();
            services.AddUnitOfWork<IAdminUnitOfWork, AdminUnitOfWork>(AppConfig.GetSection("ConnectionStrings")
                .GetSection("DefaultConnection").Value);
            builder.ContainerBuilder.Populate(services);
            builder.AddClientIntercepted(typeof(CacheProviderInterceptor));
        }
    }
}