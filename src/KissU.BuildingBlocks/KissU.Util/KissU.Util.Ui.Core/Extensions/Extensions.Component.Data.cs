﻿using KissU.Util.Ui.Abstractions.Components;
using KissU.Util.Ui.Abstractions.Components.Internal;
using KissU.Util.Ui.Abstractions.Operations.Datas;
using KissU.Util.Ui.Core.Configs;

namespace KissU.Util.Ui.Core.Extensions {
    /// <summary>
    /// 组件扩展 - 数据
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 设置Url
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="url">Url</param>
        public static TComponent Url<TComponent>( this TComponent component, string url ) where TComponent : IComponent, IUrl {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( UiConst.Url, url );
            } );
            return component;
        }

        /// <summary>
        /// 设置数据源
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="dataSource">数据源</param>
        public static TComponent DataSource<TComponent>( this TComponent component, string dataSource ) where TComponent : IComponent, IDataSource {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( UiConst.DataSource, dataSource );
            } );
            return component;
        }
    }
}
