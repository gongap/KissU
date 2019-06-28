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
    /// 企业
    /// </summary>
    [DisplayName( "企业" )]
    public partial class Enterprise : AggregateRoot<Enterprise>,IDelete,IAudited {
        /// <summary>
        /// 初始化企业
        /// </summary>
        public Enterprise() : this( Guid.Empty ) {
        }

        /// <summary>
        /// 初始化企业
        /// </summary>
        /// <param name="id">企业标识</param>
        public Enterprise( Guid id ) : base( id ) {
        }

        /// <summary>
        /// 名称
        /// </summary>
        [DisplayName( "名称" )]
        [Required(ErrorMessage = "名称不能为空")]
        [StringLength( 200 )]
        public string Name { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        [DisplayName( "是否启用" )]
        public bool Enabled { get; set; }
        /// <summary>
        /// 拼音
        /// </summary>
        [DisplayName( "拼音" )]
        [StringLength( 200 )]
        public string PinYin { get; set; }
        /// <summary>
        /// Wcf地址
        /// </summary>
        [DisplayName( "Wcf地址" )]
        [StringLength( 256 )]
        public string WcfAddress { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [DisplayName( "备注" )]
        [StringLength( 500 )]
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
        /// 添加描述
        /// </summary>
        protected override void AddDescriptions() {
            AddDescription( t => t.Id );
            AddDescription( t => t.Name );
            AddDescription( t => t.Enabled );
            AddDescription( t => t.PinYin );
            AddDescription( t => t.WcfAddress );
            AddDescription( t => t.Note );
            AddDescription( t => t.CreationTime );
            AddDescription( t => t.CreatorId );
            AddDescription( t => t.LastModificationTime );
            AddDescription( t => t.LastModifierId );
        }
        
        /// <summary>
        /// 添加变更列表
        /// </summary>
        protected override void AddChanges( Enterprise other ) {
            AddChange( t => t.Id, other.Id );
            AddChange( t => t.Name, other.Name );
            AddChange( t => t.Enabled, other.Enabled );
            AddChange( t => t.PinYin, other.PinYin );
            AddChange( t => t.WcfAddress, other.WcfAddress );
            AddChange( t => t.Note, other.Note );
            AddChange( t => t.CreationTime, other.CreationTime );
            AddChange( t => t.CreatorId, other.CreatorId );
            AddChange( t => t.LastModificationTime, other.LastModificationTime );
            AddChange( t => t.LastModifierId, other.LastModifierId );
        }
    }
}