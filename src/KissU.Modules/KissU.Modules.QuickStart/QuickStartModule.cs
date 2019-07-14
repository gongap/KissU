using Surging.Core.CPlatform;
using Surging.Core.CPlatform.Module;
using Surging.Core.System.Intercept;
using Surging.Core.ProxyGenerator;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Util.Datas.Ef;
using KissU.Modules.QuickStart.Infrastructure;
using KissU.Modules.QuickStart.Infrastructure.UnitOfWorks.SqlServer;
using Util;

namespace KissU.Modules.QuickStart
{
    /// <summary>
    /// 扩展系统模块
    /// </summary>
    public class QuickStartModule : SystemModule
    {
        /// <summary>
        /// 注册第三方组件
        /// </summary>
        /// <param name="builder">容器构建器</param>
        protected override void RegisterBuilder(ContainerBuilderWrapper builder)
        {
            base.RegisterBuilder(builder);
            var services = new ServiceCollection();
            services.AddUnitOfWork<IQuickStartUnitOfWork, QuickStartUnitOfWork>(AppConfig.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value);
            builder.ContainerBuilder.Populate(services);
            builder.AddClientIntercepted(typeof(CacheProviderInterceptor));
        }
    }
}