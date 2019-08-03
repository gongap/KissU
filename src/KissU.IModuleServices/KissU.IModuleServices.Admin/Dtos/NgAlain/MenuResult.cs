using System.Collections.Generic;
using System.Linq;
using GreatWall.Service.Dtos.Responses;
using Util;

namespace GreatWall.Service.Dtos.NgAlain {
    /// <summary>
    /// NgAlain菜单结果
    /// </summary>
    public class MenuResult {
        /// <summary>
        /// 菜单数据
        /// </summary>
        private readonly IEnumerable<MenuResponse> _data;
        /// <summary>
        /// NgAlain菜单结果
        /// </summary>
        private readonly List<MenuInfo> _result;

        /// <summary>
        /// 初始化NgAlain菜单结果
        /// </summary>
        /// <param name="data">菜单数据</param>
        public MenuResult( IEnumerable<MenuResponse> data ) {
            _data = data;
            _result = new List<MenuInfo>();
        }

        /// <summary>
        /// 获取树形结果
        /// </summary>
        public List<MenuInfo> GetResult() {
            if( _data == null )
                return _result;
            foreach( var root in _data.Where( IsRoot ) )
                AddNodes( root );
            return _result;
        }

        /// <summary>
        /// 是否根节点
        /// </summary>
        protected virtual bool IsRoot( MenuResponse dto ) {
            if( _data.Any( t => t.ParentId.IsEmpty() ) )
                return dto.ParentId.IsEmpty();
            return dto.Level == _data.Min( t => t.Level );
        }

        /// <summary>
        /// 添加节点
        /// </summary>
        private void AddNodes( MenuResponse root ) {
            var rootNode = ToNode( root );
            _result.Add( rootNode );
            AddChildren( rootNode );
        }

        /// <summary>
        /// 转换为树节点
        /// </summary>
        private MenuInfo ToNode( MenuResponse dto ) {
            var result = new MenuInfo {
                Id = dto.Id,
                Text = dto.Name,
                Icon = dto.Icon
            };
            if ( dto.External )
                result.ExternalLink = dto.Url;
            else
                result.Link = dto.Url;
            return result;
        }

        /// <summary>
        /// 添加子节点
        /// </summary>
        private void AddChildren( MenuInfo node ) {
            if( node == null )
                return;
            node.Children = GetChildren( node.Id ).Select( ToNode ).ToList();
            foreach( var child in node.Children )
                AddChildren( child );
        }

        /// <summary>
        /// 获取节点直接下级
        /// </summary>
        private List<MenuResponse> GetChildren( string parentId ) {
            return _data.Where( t => t.ParentId == parentId ).ToList();
        }
    }
}
