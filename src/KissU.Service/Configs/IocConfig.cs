using Autofac;
using Util.Dependency;
using KissU.Data;

namespace KissU.Service.Configs
{
    /// <summary>
    /// 依赖注入配置
    /// </summary>
    public class IocConfig : ConfigBase
    {
        /// <summary>
        /// 加载配置
        /// </summary>
        protected override void Load(ContainerBuilder builder)
        {
        }
    }
}