﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Util;
using Util.Domains;
using Util.Domains.Auditing;
using Util.Domains.Tenants;

namespace KissU.Modules.QuickStart.Domain.Models {
    /// <summary>
    /// 租户
    /// </summary>
    [DisplayName( "租户" )]
    public partial class Tenant : AggregateRoot<Tenant>,IDelete,IAudited {
        /// <summary>
        /// 初始化租户
        /// </summary>
        public Tenant() : this( Guid.Empty ) {
        }

        /// <summary>
        /// 初始化租户
        /// </summary>
        /// <param name="id">租户标识</param>
        public Tenant( Guid id ) : base( id ) {
        }

        /// <summary>
        /// 租户编码
        /// </summary>
        [DisplayName( "租户编码" )]
        [Required(ErrorMessage = "租户编码不能为空")]
        [StringLength( 60, ErrorMessage = "租户编码输入过长，不能超过60位" )]
        public string Code { get; set; }
        /// <summary>
        /// 租户名称
        /// </summary>
        [DisplayName( "租户名称" )]
        [Required(ErrorMessage = "租户名称不能为空")]
        [StringLength( 200, ErrorMessage = "租户名称输入过长，不能超过200位" )]
        public string Name { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [DisplayName( "备注" )]
        [StringLength( 500, ErrorMessage = "备注输入过长，不能超过500位" )]
        public string Comment { get; set; }
        /// <summary>
        /// 启用
        /// </summary>
        [DisplayName( "启用" )]
        public bool Enabled { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName( "创建时间" )]
        public DateTime? CreationTime { get; set; }
        /// <summary>
        /// 创建人编号
        /// </summary>
        [DisplayName( "创建人编号" )]
        public Guid? CreatorId { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        [DisplayName( "最后修改时间" )]
        public DateTime? LastModificationTime { get; set; }
        /// <summary>
        /// 最后修改人编号
        /// </summary>
        [DisplayName( "最后修改人编号" )]
        public Guid? LastModifierId { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        [DisplayName( "是否删除" )]
        public bool IsDeleted { get; set; }
        
        /// <summary>
        /// 添加描述
        /// </summary>
        protected override void AddDescriptions() {
            AddDescription( t => t.Id );
            AddDescription( t => t.Code );
            AddDescription( t => t.Name );
            AddDescription( t => t.Comment );
            AddDescription( t => t.Enabled );
            AddDescription( t => t.CreationTime );
            AddDescription( t => t.CreatorId );
            AddDescription( t => t.LastModificationTime );
            AddDescription( t => t.LastModifierId );
        }
        
        /// <summary>
        /// 添加变更列表
        /// </summary>
        protected override void AddChanges( Tenant other ) {
            AddChange( t => t.Id, other.Id );
            AddChange( t => t.Code, other.Code );
            AddChange( t => t.Name, other.Name );
            AddChange( t => t.Comment, other.Comment );
            AddChange( t => t.Enabled, other.Enabled );
            AddChange( t => t.CreationTime, other.CreationTime );
            AddChange( t => t.CreatorId, other.CreatorId );
            AddChange( t => t.LastModificationTime, other.LastModificationTime );
            AddChange( t => t.LastModifierId, other.LastModifierId );
        }
    }
}