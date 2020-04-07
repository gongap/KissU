using System;
using System.ComponentModel.DataAnnotations;
using KissU.Util.Ddd.Datas.Queries;

namespace KissU.Modules.GreatWall.Application.Contracts.Queries
{
    /// <summary>
    /// 用户查询参数
    /// </summary>
    public class UserQuery : QueryParameter
    {
        private string _email = string.Empty;

        private string _phoneNumber = string.Empty;

        private string _registerIp = string.Empty;

        private string _remark = string.Empty;

        private string _userName = string.Empty;

        /// <summary>
        /// 用户标识
        /// </summary>
        [Display(Name = "用户标识")]
        public Guid? UserId { get; set; }

        /// <summary>
        /// 角色标识
        /// </summary>
        public Guid? RoleId { get; set; }

        /// <summary>
        /// 排除的角色标识
        /// </summary>
        public Guid? ExceptRoleId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [Display(Name = "用户名")]
        public string UserName
        {
            get => _userName == null ? string.Empty : _userName.Trim();
            set => _userName = value;
        }

        /// <summary>
        /// 安全邮箱
        /// </summary>
        [Display(Name = "安全邮箱")]
        public string Email
        {
            get => _email == null ? string.Empty : _email.Trim();
            set => _email = value;
        }

        /// <summary>
        /// 邮箱已确认
        /// </summary>
        [Display(Name = "邮箱已确认")]
        public bool? EmailConfirmed { get; set; }

        /// <summary>
        /// 安全手机
        /// </summary>
        [Display(Name = "安全手机")]
        public string PhoneNumber
        {
            get => _phoneNumber == null ? string.Empty : _phoneNumber.Trim();
            set => _phoneNumber = value;
        }

        /// <summary>
        /// 手机已确认
        /// </summary>
        [Display(Name = "手机已确认")]
        public bool? PhoneNumberConfirmed { get; set; }

        /// <summary>
        /// 启用
        /// </summary>
        [Display(Name = "启用")]
        public bool? Enabled { get; set; }

        /// <summary>
        /// 起始冻结时间
        /// </summary>
        [Display(Name = "起始冻结时间")]
        public DateTime? BeginDisabledTime { get; set; }

        /// <summary>
        /// 结束冻结时间
        /// </summary>
        [Display(Name = "结束冻结时间")]
        public DateTime? EndDisabledTime { get; set; }

        /// <summary>
        /// 注册Ip
        /// </summary>
        [Display(Name = "注册Ip")]
        public string RegisterIp
        {
            get => _registerIp == null ? string.Empty : _registerIp.Trim();
            set => _registerIp = value;
        }

        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        public string Remark
        {
            get => _remark == null ? string.Empty : _remark.Trim();
            set => _remark = value;
        }

        /// <summary>
        /// 起始创建时间
        /// </summary>
        [Display(Name = "起始创建时间")]
        public DateTime? BeginCreationTime { get; set; }

        /// <summary>
        /// 结束创建时间
        /// </summary>
        [Display(Name = "结束创建时间")]
        public DateTime? EndCreationTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [Display(Name = "创建人")]
        public Guid? CreatorId { get; set; }
    }
}