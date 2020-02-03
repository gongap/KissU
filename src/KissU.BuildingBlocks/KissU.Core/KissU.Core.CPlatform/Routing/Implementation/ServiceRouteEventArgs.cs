namespace KissU.Core.CPlatform.Routing.Implementation
{
    /// <summary>
    /// 服务路由事件参数。
    /// </summary>
    public class ServiceRouteEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceRouteEventArgs" /> class.
        /// </summary>
        /// <param name="route">The route.</param>
        public ServiceRouteEventArgs(ServiceRoute route)
        {
            Route = route;
        }

        /// <summary>
        /// 服务路由信息。
        /// </summary>
        public ServiceRoute Route { get; private set; }
    }
}