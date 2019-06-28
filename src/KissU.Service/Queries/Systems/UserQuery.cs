using System;
using System.ComponentModel.DataAnnotations;
using Util;
using Util.Datas.Queries;

namespace KissU.Service.Queries.Systems {
    /// <summary>
    /// 用户查询参数
    /// </summary>
    public class UserQuery : QueryParameter {
        /// <summary>
        /// 
        /// </summary>
        [Display(Name="")]
        public Guid? UserId { get; set; }
        
        private string _userName = string.Empty;
        /// <summary>
        /// 用户名
        /// </summary>
        [Display(Name="用户名")]
        public string UserName {
            get => _userName == null ? string.Empty : _userName.Trim();
            set => _userName = value;
        }
        
        private string _realName = string.Empty;
        /// <summary>
        /// 真实姓名
        /// </summary>
        [Display(Name="真实姓名")]
        public string RealName {
            get => _realName == null ? string.Empty : _realName.Trim();
            set => _realName = value;
        }
        
        private string _nickName = string.Empty;
        /// <summary>
        /// 昵称
        /// </summary>
        [Display(Name="昵称")]
        public string NickName {
            get => _nickName == null ? string.Empty : _nickName.Trim();
            set => _nickName = value;
        }
        
        private string _email = string.Empty;
        /// <summary>
        /// 邮箱
        /// </summary>
        [Display(Name="邮箱")]
        public string Email {
            get => _email == null ? string.Empty : _email.Trim();
            set => _email = value;
        }
        /// <summary>
        /// 邮箱是否验证
        /// </summary>
        [Display(Name="邮箱是否验证")]
        public bool? EmailConfirmed { get; set; }
        
        private string _phoneNumber = string.Empty;
        /// <summary>
        /// 手机号码
        /// </summary>
        [Display(Name="手机号码")]
        public string PhoneNumber {
            get => _phoneNumber == null ? string.Empty : _phoneNumber.Trim();
            set => _phoneNumber = value;
        }
        /// <summary>
        /// 手机号码是否验证
        /// </summary>
        [Display(Name="手机号码是否验证")]
        public bool? PhoneNumberConfirmed { get; set; }
        
        private string _password = string.Empty;
        /// <summary>
        /// 密码
        /// </summary>
        [Display(Name="密码")]
        public string Password {
            get => _password == null ? string.Empty : _password.Trim();
            set => _password = value;
        }
        
        private string _passwordHash = string.Empty;
        /// <summary>
        /// 密码哈希值
        /// </summary>
        [Display(Name="密码哈希值")]
        public string PasswordHash {
            get => _passwordHash == null ? string.Empty : _passwordHash.Trim();
            set => _passwordHash = value;
        }
        /// <summary>
        /// 起始
        /// </summary>
        [Display( Name = "起始" )]
        public DateTime? BeginCreationTime { get; set; }
        /// <summary>
        /// 结束
        /// </summary>
        [Display( Name = "结束" )]
        public DateTime? EndCreationTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display(Name="")]
        public Guid? CreatorId { get; set; }
        /// <summary>
        /// 起始
        /// </summary>
        [Display( Name = "起始" )]
        public DateTime? BeginLastModificationTime { get; set; }
        /// <summary>
        /// 结束
        /// </summary>
        [Display( Name = "结束" )]
        public DateTime? EndLastModificationTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display(Name="")]
        public Guid? LastModifierId { get; set; }
    }
}