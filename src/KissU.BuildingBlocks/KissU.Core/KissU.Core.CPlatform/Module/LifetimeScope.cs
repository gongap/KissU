namespace KissU.Core.CPlatform.Module
{
    /// <summary>
    /// 组件生命周期枚举类
    /// </summary>
    public enum LifetimeScope
    {
        /// <summary>
        /// 每个依赖项的实例
        /// </summary>
        InstancePerDependency,

        /// <summary>
        /// 每个HTTP请求的实例
        /// </summary>
        InstancePerHttpRequest,

        /// <summary>
        /// 单实例
        /// </summary>
        SingleInstance,
    }
}