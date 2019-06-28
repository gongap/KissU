using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Util.Ui.Attributes;
using Util.Applications.Dtos;

namespace KissU.Service.Dtos.Systems {
    /// <summary>
    /// 用户参数
    /// </summary>
    public class UserDto : DtoBase {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage = "用户名不能为空")]
        [StringLength( 256 )]
        [Display( Name = "用户名" )]
        public string UserName { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        [StringLength( 256 )]
        [Display( Name = "真实姓名" )]
        public string RealName { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        [StringLength( 256 )]
        [Display( Name = "昵称" )]
        public string NickName { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        [StringLength( 256 )]
        [Display( Name = "邮箱" )]
        public string Email { get; set; }
        /// <summary>
        /// 邮箱是否验证
        /// </summary>
        [Display( Name = "邮箱是否验证" )]
        public bool? EmailConfirmed { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        [StringLength( 64 )]
        [Display( Name = "手机号码" )]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 手机号码是否验证
        /// </summary>
        [Display( Name = "手机号码是否验证" )]
        public bool? PhoneNumberConfirmed { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [StringLength( 256 )]
        [Display( Name = "密码" )]
        public string Password { get; set; }
        /// <summary>
        /// 密码哈希值
        /// </summary>
        [Required(ErrorMessage = "密码哈希值不能为空")]
        [StringLength( 1024 )]
        [Display( Name = "密码哈希值" )]
        public string PasswordHash { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display( Name = "" )]
        public DateTime? CreationTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display( Name = "" )]
        public Guid? CreatorId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display( Name = "" )]
        public DateTime? LastModificationTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display( Name = "" )]
        public Guid? LastModifierId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display( Name = "" )]
        public Byte[] Version { get; set; }
    }
}