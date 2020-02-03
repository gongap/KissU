using System.Text;

namespace KissU.Core.CPlatform.Module
{
    /// <summary>
    /// 组件类
    /// </summary>
    public class Component
    {
        /// <summary>
        /// 服务类型.
        /// </summary>
        public string ServiceType { get; set; }

        /// <summary>
        /// 实现的类型.
        /// </summary>
        public string ImplementType { get; set; }

        /// <summary>
        /// 生命周期范围
        /// </summary>
        public LifetimeScope LifetimeScope { get; set; }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="string" /> that represents this instance.</returns>
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
    }
}