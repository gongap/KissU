using Autofac;
using Util.Dependency;
using KissU.GreatWall.Data;

namespace KissU.GreatWall.Service.Configs {
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
            builder.AddScoped<IKissU.GreatWallUnitOfWork, KissU.GreatWallUnitOfWork>();
        }

        /// <summary>
        /// 加载仓储
        /// </summary>
        protected virtual void LoadRepositories( ContainerBuilder builder ) {
            builder.AddScoped<IApplicationRepository,ApplicationRepository>();
            builder.AddScoped<IResourceRepository,ResourceRepository>();
            builder.AddScoped<IRoleRepository,RoleRepository>();
            builder.AddScoped<IUserRepository,UserRepository>();
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
            builder.AddScoped<IApplicationService,ApplicationService>().PropertiesAutowired();
            builder.AddScoped<IResourceService,ResourceService>().PropertiesAutowired();
            builder.AddScoped<IRoleService,RoleService>().PropertiesAutowired();
            builder.AddScoped<IUserService,UserService>().PropertiesAutowired();
        }
    }
}