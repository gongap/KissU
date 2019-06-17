﻿using Autofac;
using Util.Dependency;
using KissU.Data;

namespace KissU.Service.Configs {
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
            LoadDomainServices( builder );
            LoadApplicationServices( builder );
        }

        /// <summary>
        /// 加载基础设施
        /// </summary>
        protected virtual void LoadInfrastructure( ContainerBuilder builder ) {
            builder.AddScoped<IKissUUnitOfWork, KissUUnitOfWork>();
        }

        /// <summary>
        /// 加载仓储
        /// </summary>
        protected virtual void LoadRepositories( ContainerBuilder builder ) {
            builder.AddScoped<IMenuRepository,MenuRepository>();
        }
        
        /// <summary>
        /// 加载领域服务
        /// </summary>
        protected virtual void LoadDomainServices( ContainerBuilder builder ) {
        }
        
        /// <summary>
        /// 加载应用服务
        /// </summary>
        protected virtual void LoadApplicationServices( ContainerBuilder builder ) {
            builder.AddScoped<IMenuService,MenuService>().PropertiesAutowired();
        }
    }
}