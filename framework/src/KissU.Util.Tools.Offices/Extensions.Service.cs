using KissU.Util.Tools.Offices.Npoi;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace KissU.Util.Tools.Offices
{
    /// <summary>
    /// Office操作扩展
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// 注册Npoi Office操作服务
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection AddNpoi(this IServiceCollection services)
        {
            services.TryAddSingleton<IExportFactory, ExportFactory>();
            return services;
        }
    }
}