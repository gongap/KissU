namespace KissU.Core.CPlatform.Routing.Implementation
{
    /// <summary>
    /// 服务路由变更事件参数。
    /// </summary>
    public class ServiceRouteChangedEventArgs : ServiceRouteEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceRouteChangedEventArgs" /> class.
        /// </summary>
        /// <param name="route">The route.</param>
        /// <param name="oldRoute">The old route.</param>
        public ServiceRouteChangedEventArgs(ServiceRoute route, ServiceRoute oldRoute) : base(route)
        {
            OldRoute = oldRoute;
        }

        /// <summary>
        /// 旧的服务路由信息。
        /// </summary>
        public ServiceRoute OldRoute { get; set; }
    }
}