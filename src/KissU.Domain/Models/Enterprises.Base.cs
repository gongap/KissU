using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Util;
using Util.Domains;
using Util.Domains.Auditing;
using Util.Domains.Tenants;

namespace KissU.Domain.Models {
    /// <summary>
    /// 
    /// </summary>
    [DisplayName( "" )]
    public partial class Enterprises : AggregateRoot<Enterprises>,IDelete,IAudited {
        /// <summary>
        /// 初始化
        /// </summary>
        public Enterprises() : this( Guid.Empty ) {
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="id">标识</param>
        public Enterprises( Guid id ) : base( id ) {
        }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName( "" )]
        [Required(ErrorMessage = "不能为空")]
        public Guid TenantId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DisplayName( "" )]
        [Required(ErrorMessage = "不能为空")]
        [StringLength( 200, ErrorMessage = "输入过长，不能超过200位" )]
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DisplayName( "" )]
        public bool Enabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DisplayName( "" )]
        [StringLength( 200, ErrorMessage = "输入过长，不能超过200位" )]
        public string PinYin { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DisplayName( "" )]
        [StringLength( 256, ErrorMessage = "输入过长，不能超过256位" )]
        public string WcfAddress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DisplayName( "" )]
        [StringLength( 500, ErrorMessage = "输入过长，不能超过500位" )]
        public string Note { get; set; }
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
        /// 
        /// </summary>
        [DisplayName( "" )]
        public Guid? Id { get; set; }
        
        /// <summary>
        /// 添加描述
        /// </summary>
        protected override void AddDescriptions() {
            AddDescription( t => t.Id );
            AddDescription( t => t.TenantId );
            AddDescription( t => t.Name );
            AddDescription( t => t.Enabled );
            AddDescription( t => t.PinYin );
            AddDescription( t => t.WcfAddress );
            AddDescription( t => t.Note );
            AddDescription( t => t.CreationTime );
            AddDescription( t => t.CreatorId );
            AddDescription( t => t.LastModificationTime );
            AddDescription( t => t.LastModifierId );
            AddDescription( t => t.Id );
        }
        
        /// <summary>
        /// 添加变更列表
        /// </summary>
        protected override void AddChanges( Enterprises other ) {
            AddChange( t => t.Id, other.Id );
            AddChange( t => t.TenantId, other.TenantId );
            AddChange( t => t.Name, other.Name );
            AddChange( t => t.Enabled, other.Enabled );
            AddChange( t => t.PinYin, other.PinYin );
            AddChange( t => t.WcfAddress, other.WcfAddress );
            AddChange( t => t.Note, other.Note );
            AddChange( t => t.CreationTime, other.CreationTime );
            AddChange( t => t.CreatorId, other.CreatorId );
            AddChange( t => t.LastModificationTime, other.LastModificationTime );
            AddChange( t => t.LastModifierId, other.LastModifierId );
            AddChange( t => t.Id, other.Id );
        }
    }
}