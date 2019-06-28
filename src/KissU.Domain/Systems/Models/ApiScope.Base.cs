using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Util;
using Util.Domains;
using Util.Domains.Auditing;
using Util.Domains.Tenants;

namespace KissU.Domain.Systems.Models {
    /// <summary>
    /// Api许可范围
    /// </summary>
    [DisplayName( "Api许可范围" )]
    public partial class ApiScope : AggregateRoot<ApiScope>,IAudited {
        /// <summary>
        /// 初始化Api许可范围
        /// </summary>
        public ApiScope() : this( Guid.Empty ) {
        }

        /// <summary>
        /// 初始化Api许可范围
        /// </summary>
        /// <param name="id">Api许可范围标识</param>
        public ApiScope( Guid id ) : base( id ) {
        }

        /// <summary>
        /// Api资源标识
        /// </summary>
        [DisplayName( "Api资源标识" )]
        [Required(ErrorMessage = "Api资源标识不能为空")]
        public Guid ApiId { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [DisplayName( "名称" )]
        [Required(ErrorMessage = "名称不能为空")]
        [StringLength( 200 )]
        public string Name { get; set; }
        /// <summary>
        /// 显示名
        /// </summary>
        [DisplayName( "显示名" )]
        [StringLength( 200 )]
        public string DisplayName { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [DisplayName( "描述" )]
        [StringLength( 1000 )]
        public string Description { get; set; }
        /// <summary>
        /// 声明类型
        /// </summary>
        [DisplayName( "声明类型" )]
        [StringLength( 2000 )]
        public string ClaimTypes { get; set; }
        /// <summary>
        /// 是否必选
        /// </summary>
        [DisplayName( "是否必选" )]
        public bool Required { get; set; }
        /// <summary>
        /// 是否强调
        /// </summary>
        [DisplayName( "是否强调" )]
        public bool Emphasize { get; set; }
        /// <summary>
        /// 是否显示在发现文档中
        /// </summary>
        [DisplayName( "是否显示在发现文档中" )]
        public bool ShowInDiscoveryDocument { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DisplayName( "" )]
        public DateTime? CreationTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DisplayName( "" )]
        public Guid? CreatorId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DisplayName( "" )]
        public DateTime? LastModificationTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DisplayName( "" )]
        public Guid? LastModifierId { get; set; }
        
        /// <summary>
        /// 添加描述
        /// </summary>
        protected override void AddDescriptions() {
            AddDescription( t => t.Id );
            AddDescription( t => t.ApiId );
            AddDescription( t => t.Name );
            AddDescription( t => t.DisplayName );
            AddDescription( t => t.Description );
            AddDescription( t => t.ClaimTypes );
            AddDescription( t => t.Required );
            AddDescription( t => t.Emphasize );
            AddDescription( t => t.ShowInDiscoveryDocument );
            AddDescription( t => t.CreationTime );
            AddDescription( t => t.CreatorId );
            AddDescription( t => t.LastModificationTime );
            AddDescription( t => t.LastModifierId );
        }
        
        /// <summary>
        /// 添加变更列表
        /// </summary>
        protected override void AddChanges( ApiScope other ) {
            AddChange( t => t.Id, other.Id );
            AddChange( t => t.ApiId, other.ApiId );
            AddChange( t => t.Name, other.Name );
            AddChange( t => t.DisplayName, other.DisplayName );
            AddChange( t => t.Description, other.Description );
            AddChange( t => t.ClaimTypes, other.ClaimTypes );
            AddChange( t => t.Required, other.Required );
            AddChange( t => t.Emphasize, other.Emphasize );
            AddChange( t => t.ShowInDiscoveryDocument, other.ShowInDiscoveryDocument );
            AddChange( t => t.CreationTime, other.CreationTime );
            AddChange( t => t.CreatorId, other.CreatorId );
            AddChange( t => t.LastModificationTime, other.LastModificationTime );
            AddChange( t => t.LastModifierId, other.LastModifierId );
        }
    }
}