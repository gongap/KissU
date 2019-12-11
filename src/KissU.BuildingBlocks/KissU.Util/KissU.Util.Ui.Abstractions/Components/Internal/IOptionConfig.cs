using System;
using KissU.Util.Ui.Abstractions.Configs;

namespace KissU.Util.Ui.Abstractions.Components.Internal {
    /// <summary>
    /// 组件配置
    /// </summary>
    public interface IOptionConfig {
        /// <summary>
        /// 配置
        /// </summary>
        /// <typeparam name="TConfig">配置类型</typeparam>
        /// <param name="configAction">配置操作</param>
        void Config<TConfig>( Action<TConfig> configAction ) where TConfig : IConfig;
    }
}
