using KissU.Util.Ui.Abstractions.Components;
using KissU.Util.Ui.Abstractions.Components.Internal;
using KissU.Util.Ui.Abstractions.Operations.Forms;
using KissU.Util.Ui.Core.Configs;

namespace KissU.Util.Ui.Core.Extensions {
    /// <summary>
    /// 组件扩展 - 表单
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 设置占位提示符
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="text">文本</param>
        public static TComponent Placeholder<TComponent>( this TComponent component, string text ) where TComponent : IComponent, IPlaceholder {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( UiConst.Placeholder, text );
            } );
            return component;
        }

        /// <summary>
        /// 模型绑定
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="model">模型</param>
        public static TComponent Model<TComponent>( this TComponent component, string model ) where TComponent : IModel {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( UiConst.Model, model );
            } );
            return component;
        }
    }
}
