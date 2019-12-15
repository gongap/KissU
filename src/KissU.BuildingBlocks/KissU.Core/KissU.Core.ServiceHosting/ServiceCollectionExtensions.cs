using Microsoft.Extensions.DependencyInjection;

namespace KissU.Core.ServiceHosting
{
    internal static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 克隆
        /// </summary>
        /// <param name="serviceCollection">服务集合</param>
        /// <returns>新的服务集合</returns>
        public static IServiceCollection Clone(this IServiceCollection serviceCollection)
        {
            IServiceCollection clone = new ServiceCollection();
            foreach (var service in serviceCollection)
            {
                clone.Add(service);
            }

            return clone;
        }
    }
}
