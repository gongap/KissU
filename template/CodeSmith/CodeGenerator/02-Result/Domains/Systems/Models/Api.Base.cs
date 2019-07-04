using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Util;
using Util.Domains;
using Util.Domains.Auditing;
using Util.Domains.Tenants;

namespace GreatWall.Systems.Domain.Models {
    /// <summary>
    /// Api资源
    /// </summary>
    [DisplayName( "Api资源" )]
    public partial class Api : AggregateRoot<Api>,IDelete,IAudited {
        /// <summary>
        /// 初始化Api资源
        /// </summary>
        public Api() : this( Guid.Empty ) {
        }

        /// <summary>
        /// 初始化Api资源
        /// </summary>
        /// <param name="id">Api资源标识</param>
        public Api( Guid id ) : base( id ) {
        }

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
        /// 是否启用
        /// </summary>
        [DisplayName( "是否启用" )]
        public bool Enabled { get; set; }
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
        /// 
        /// </summary>
        [DisplayName( "" )]
        public bool IsDeleted { get; set; }
        
        /// <summary>
        /// 添加描述
        /// </summary>
        protected override void AddDescriptions() {
            AddDescription( t => t.Id );
            AddDescription( t => t.Name );
            AddDescription( t => t.DisplayName );
            AddDescription( t => t.Description );
            AddDescription( t => t.ClaimTypes );
            AddDescription( t => t.Enabled );
            AddDescription( t => t.CreationTime );
            AddDescription( t => t.CreatorId );
            AddDescription( t => t.LastModificationTime );
            AddDescription( t => t.LastModifierId );
        }
        
        /// <summary>
        /// 添加变更列表
        /// </summary>
        protected override void AddChanges( Api other ) {
            AddChange( t => t.Id, other.Id );
            AddChange( t => t.Name, other.Name );
            AddChange( t => t.DisplayName, other.DisplayName );
            AddChange( t => t.Description, other.Description );
            AddChange( t => t.ClaimTypes, other.ClaimTypes );
            AddChange( t => t.Enabled, other.Enabled );
            AddChange( t => t.CreationTime, other.CreationTime );
            AddChange( t => t.CreatorId, other.CreatorId );
            AddChange( t => t.LastModificationTime, other.LastModificationTime );
            AddChange( t => t.LastModifierId, other.LastModifierId );
        }
    }
}