using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KissU.Util;
using KissU.Util.Domains;

namespace KissU.Modules.GreatWall.Domain.Models {
    /// <summary>
    /// Api资源
    /// </summary>
    [DisplayName( "Api资源" )]
    public partial class ApiResource : AggregateRoot<ApiResource> {
        /// <summary>
        /// 初始化Api资源
        /// </summary>
        public ApiResource() : this( Guid.Empty ) {
        }

        /// <summary>
        /// 初始化Api资源
        /// </summary>
        /// <param name="id">资源标识</param>
        public ApiResource( Guid id ) : base( id ) {
        }

        /// <summary>
        /// 资源标识
        /// </summary>
        [DisplayName( "资源标识" )]
        [Required( ErrorMessage = "资源标识不能为空" )]
        [StringLength( 300 )]
        public string Uri { get; set; }
        /// <summary>
        /// 显示名称
        /// </summary>
        [DisplayName( "显示名称" )]
        [Required( ErrorMessage = "显示名称不能为空" )]
        [StringLength( 200 )]
        public string Name { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [DisplayName( "描述" )]
        [StringLength( 500 )]
        public string Remark { get; set; }
        /// <summary>
        /// 启用
        /// </summary>
        [DisplayName( "启用" )]
        public bool Enabled { get; set; }
        /// <summary>
        /// 排序号
        /// </summary>
        [DisplayName( "排序号" )]
        public int? SortId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName( "创建时间" )]
        public DateTime? CreationTime { get; set; }
        /// <summary>
        /// 创建人标识
        /// </summary>
        [DisplayName( "创建人标识" )]
        public Guid? CreatorId { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        [DisplayName( "最后修改时间" )]
        public DateTime? LastModificationTime { get; set; }
        /// <summary>
        /// 最后修改人标识
        /// </summary>
        [DisplayName( "最后修改人标识" )]
        public Guid? LastModifierId { get; set; }
        /// <summary>
        /// 用户声明
        /// </summary>
        public List<string> Claims { get; set; }

        /// <summary>
        /// 添加描述
        /// </summary>
        protected override void AddDescriptions() {
            AddDescription( t => t.Id );
            AddDescription( t => t.Uri );
            AddDescription( t => t.Name );
            AddDescription( t => t.Remark );
            AddDescription( t => t.Enabled );
            AddDescription( "用户声明", Claims.Join() );
            AddDescription( t => t.SortId );
            AddDescription( t => t.CreationTime );
            AddDescription( t => t.CreatorId );
            AddDescription( t => t.LastModificationTime );
            AddDescription( t => t.LastModifierId );
        }

        /// <summary>
        /// 添加变更列表
        /// </summary>
        protected override void AddChanges( ApiResource other ) {
            AddChange( t => t.Id, other.Id );
            AddChange( t => t.Uri, other.Uri );
            AddChange( t => t.Name, other.Name );
            AddChange( t => t.Remark, other.Remark );
            AddChange( t => t.Enabled, other.Enabled );
            AddChange( t => t.SortId, other.SortId );
            AddChange( t => t.CreationTime, other.CreationTime );
            AddChange( t => t.CreatorId, other.CreatorId );
            AddChange( t => t.LastModificationTime, other.LastModificationTime );
            AddChange( t => t.LastModifierId, other.LastModifierId );
        }
    }
}