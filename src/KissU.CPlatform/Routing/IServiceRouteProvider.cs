using System.Threading.Tasks;

namespace KissU.CPlatform.Routing
{
    /// <summary>
    /// 服务路由接口
    /// </summary>
    public interface IServiceRouteProvider
    {
        /// <summary>
        /// 根据服务id找到相关服务信息
        /// </summary>
        /// <param name="serviceId">The service identifier.</param>
        /// <returns>Task&lt;ServiceRoute&gt;.</returns>
        Task<ServiceRoute> Locate(string serviceId);

        /// <summary>
        /// 通过路径正则表达式获取本地路由.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>ValueTask&lt;ServiceRoute&gt;.</returns>
        ValueTask<ServiceRoute> GetLocalRouteByPathRegex(string path);

        /// <summary>
        /// 根据服务路由路径获取路由信息
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>ValueTask&lt;ServiceRoute&gt;.</returns>
        ValueTask<ServiceRoute> GetRouteByPath(string path);

        /// <summary>
        /// 根据服务路由路径找到相关服务信息
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>Task&lt;ServiceRoute&gt;.</returns>
        Task<ServiceRoute> SearchRoute(string path);

        /// <summary>
        /// 注册路由
        /// </summary>
        /// <param name="processorTime">The processor time.</param>
        /// <returns>Task.</returns>
        Task RegisterRoutes(decimal processorTime);

        /// <summary>
        /// 通过路径正则表达式获取路线.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>ValueTask&lt;ServiceRoute&gt;.</returns>
        ValueTask<ServiceRoute> GetRouteByPathRegex(string path);
    }
}