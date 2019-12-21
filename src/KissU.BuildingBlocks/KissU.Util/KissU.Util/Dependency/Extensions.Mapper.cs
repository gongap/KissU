using System.Linq;
using AutoMapper;
using KissU.Util.Reflections;
using Microsoft.Extensions.DependencyInjection;

namespace KissU.Util.Dependency
{
    /// <summary>
    /// 对象映射
    /// </summary>
    public static class Mappers
    {
        /// <summary>
        /// 添加AutoMapper映射配置
        /// </summary>
        public static void AddMapper(this IServiceCollection services)
        {
            var finder = new Finder();
            var assemblies = finder.GetAssemblies();
            services.AddAutoMapper(assemblies);
        }
    }
}
