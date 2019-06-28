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
    /// 用户
    /// </summary>
    [DisplayName( "用户" )]
    public partial class User : AggregateRoot<User>,IDelete,IAudited {
        /// <summary>
        /// 初始化用户
        /// </summary>
        public User() : this( Guid.Empty ) {
        }

        /// <summary>
        /// 初始化用户
        /// </summary>
        /// <param name="id">用户标识</param>
        public User( Guid id ) : base( id ) {
        }

        /// <summary>
        /// 用户名
        /// </summary>
        [DisplayName( "用户名" )]
        [Required(ErrorMessage = "用户名不能为空")]
        [StringLength( 256 )]
        public string UserName { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        [DisplayName( "真实姓名" )]
        [StringLength( 256 )]
        public string RealName { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        [DisplayName( "昵称" )]
        [StringLength( 256 )]
        public string NickName { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        [DisplayName( "邮箱" )]
        [StringLength( 256 )]
        public string Email { get; set; }
        /// <summary>
        /// 邮箱是否验证
        /// </summary>
        [DisplayName( "邮箱是否验证" )]
        public bool EmailConfirmed { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        [DisplayName( "手机号码" )]
        [StringLength( 64 )]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 手机号码是否验证
        /// </summary>
        [DisplayName( "手机号码是否验证" )]
        public bool PhoneNumberConfirmed { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [DisplayName( "密码" )]
        [StringLength( 256 )]
        public string Password { get; set; }
        /// <summary>
        /// 密码哈希值
        /// </summary>
        [DisplayName( "密码哈希值" )]
        [Required(ErrorMessage = "密码哈希值不能为空")]
        [StringLength( 1024 )]
        public string PasswordHash { get; set; }
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
            AddDescription( t => t.UserName );
            AddDescription( t => t.RealName );
            AddDescription( t => t.NickName );
            AddDescription( t => t.Email );
            AddDescription( t => t.EmailConfirmed );
            AddDescription( t => t.PhoneNumber );
            AddDescription( t => t.PhoneNumberConfirmed );
            AddDescription( t => t.Password );
            AddDescription( t => t.PasswordHash );
            AddDescription( t => t.CreationTime );
            AddDescription( t => t.CreatorId );
            AddDescription( t => t.LastModificationTime );
            AddDescription( t => t.LastModifierId );
        }
        
        /// <summary>
        /// 添加变更列表
        /// </summary>
        protected override void AddChanges( User other ) {
            AddChange( t => t.Id, other.Id );
            AddChange( t => t.UserName, other.UserName );
            AddChange( t => t.RealName, other.RealName );
            AddChange( t => t.NickName, other.NickName );
            AddChange( t => t.Email, other.Email );
            AddChange( t => t.EmailConfirmed, other.EmailConfirmed );
            AddChange( t => t.PhoneNumber, other.PhoneNumber );
            AddChange( t => t.PhoneNumberConfirmed, other.PhoneNumberConfirmed );
            AddChange( t => t.Password, other.Password );
            AddChange( t => t.PasswordHash, other.PasswordHash );
            AddChange( t => t.CreationTime, other.CreationTime );
            AddChange( t => t.CreatorId, other.CreatorId );
            AddChange( t => t.LastModificationTime, other.LastModificationTime );
            AddChange( t => t.LastModifierId, other.LastModifierId );
        }
    }
}