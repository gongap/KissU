using KissU.Util.Dependency;
using Microsoft.Extensions.DependencyInjection;

namespace KissU.Modules.IdentityServer.Application.Configs
{
    /// <summary>
    /// 服务注册
    /// </summary>
    public class ServiceRegister : IDependencyRegistrar
    {
        /// <summary>
        /// 注册依赖
        /// </summary>
        /// <param name="services">The services.</param>
        public void Register(IServiceCollection services)
        {
        }
    }
}