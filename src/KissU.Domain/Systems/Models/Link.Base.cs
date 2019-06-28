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
    /// 链接
    /// </summary>
    [DisplayName( "链接" )]
    public partial class Link : AggregateRoot<Link>,IDelete,IAudited {
        /// <summary>
        /// 初始化链接
        /// </summary>
        public Link() : this( Guid.Empty ) {
        }

        /// <summary>
        /// 初始化链接
        /// </summary>
        /// <param name="id">链接标识</param>
        public Link( Guid id ) : base( id ) {
        }

        /// <summary>
        /// 编码
        /// </summary>
        [DisplayName( "编码" )]
        [Required(ErrorMessage = "编码不能为空")]
        [StringLength( 50 )]
        public string Code { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        [DisplayName( "标题" )]
        [StringLength( 256 )]
        public string Title { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        [DisplayName( "地址" )]
        [Required(ErrorMessage = "地址不能为空")]
        [StringLength( 16 )]
        public string Address { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        [DisplayName( "图片" )]
        [StringLength( 256 )]
        public string Image { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [DisplayName( "备注" )]
        [StringLength( 500 )]
        public string Comment { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        [DisplayName( "是否启用" )]
        public bool? Enabled { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [DisplayName( "状态" )]
        public int? Status { get; set; }
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
            AddDescription( t => t.Code );
            AddDescription( t => t.Title );
            AddDescription( t => t.Address );
            AddDescription( t => t.Image );
            AddDescription( t => t.Comment );
            AddDescription( t => t.Enabled );
            AddDescription( t => t.Status );
            AddDescription( t => t.CreationTime );
            AddDescription( t => t.CreatorId );
            AddDescription( t => t.LastModificationTime );
            AddDescription( t => t.LastModifierId );
        }
        
        /// <summary>
        /// 添加变更列表
        /// </summary>
        protected override void AddChanges( Link other ) {
            AddChange( t => t.Id, other.Id );
            AddChange( t => t.Code, other.Code );
            AddChange( t => t.Title, other.Title );
            AddChange( t => t.Address, other.Address );
            AddChange( t => t.Image, other.Image );
            AddChange( t => t.Comment, other.Comment );
            AddChange( t => t.Enabled, other.Enabled );
            AddChange( t => t.Status, other.Status );
            AddChange( t => t.CreationTime, other.CreationTime );
            AddChange( t => t.CreatorId, other.CreatorId );
            AddChange( t => t.LastModificationTime, other.LastModificationTime );
            AddChange( t => t.LastModifierId, other.LastModifierId );
        }
    }
}