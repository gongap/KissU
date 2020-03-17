using System.Text;

namespace KissU.Surging.System.Module
{
    #region 组件生命周期枚举类

    /// <summary>
    /// 组件生命周期枚举。
    /// </summary>
    /// <remarks>
    ///     <para>创建：范亮</para>
    ///     <para>日期：2015/12/4</para>
    /// </remarks>
    public enum LifetimeScope
    {
        /// <summary>
        /// 每次依赖的时候实例化对象。
        /// </summary>
        InstancePerDependency,

        /// <summary>
        /// 每次 Http Request 请求的时候实例化对象。
        /// </summary>
        InstancePerHttpRequest,

        /// <summary>
        /// 单实例化对象。
        /// </summary>
        SingleInstance
    }

    #endregion

    #region 组件类

    /// <summary>
    /// 组件描述类(定义了接口+实现类)。
    /// </summary>
    /// <remarks>
    ///     <para>创建：范亮</para>
    ///     <para>日期：2015/12/4</para>
    /// </remarks>
    public class Component
    {
        #region 实例方法

        /// <summary>
        /// 获取组件的字符串文本描述信息。
        /// </summary>
        /// <returns>返回组件对象的字符串文本描述信息。</returns>
        /// <remarks>
        ///     <para>创建：范亮</para>
        ///     <para>日期：2015/12/4</para>
        /// </remarks>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("接口类型：{0}", ServiceType);
            sb.AppendLine();
            sb.AppendFormat("实现类型：{0}", ImplementType);
            sb.AppendLine();
            sb.AppendFormat("生命周期：{0}", LifetimeScope);
            return sb.ToString();
        }

        #endregion

        #region 实例属性

        /// <summary>
        /// 获取或设置接口服务类型名称(包含程序集名称的限定名)。
        /// </summary>
        /// <remarks>
        ///     <para>创建：范亮</para>
        ///     <para>日期：2015/12/4</para>
        /// </remarks>
        public string ServiceType { get; set; }

        /// <summary>
        /// 获取或设置接口实现类的类型名称(包含程序集名称的限定名)。
        /// </summary>
        /// <remarks>
        ///     <para>创建：范亮</para>
        ///     <para>日期：2015/12/4</para>
        /// </remarks>
        public string ImplementType { get; set; }

        /// <summary>
        /// 获取或设置组件生命周期枚举。
        /// </summary>
        /// <remarks>
        ///     <para>创建：范亮</para>
        ///     <para>日期：2015/12/4</para>
        /// </remarks>
        public LifetimeScope LifetimeScope { get; set; }

        #endregion
    }

    #endregion
}