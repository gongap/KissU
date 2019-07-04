using System;
using Util.Domains;
using Util.Domains.Auditing;
using Util.Datas.Persistence;

namespace GreatWall.Data.Pos.Systems{
    /// <summary>
    /// 用户持久化对象
    /// </summary>
    public class UserPo : PersistentObjectBase<Guid>,IDelete,IAudited{
        /// <summary>
        /// 用户名
        /// </summary>  
        public string UserName { get; set; }
        /// <summary>
        /// 标准化用户名
        /// </summary>  
        public string NormalizedUserName { get; set; }
        /// <summary>
        /// 安全邮箱
        /// </summary>  
        public string Email { get; set; }
        /// <summary>
        /// 标准化邮箱
        /// </summary>  
        public string NormalizedEmail { get; set; }
        /// <summary>
        /// 邮箱已确认
        /// </summary>  
        public bool EmailConfirmed { get; set; }
        /// <summary>
        /// 安全手机
        /// </summary>  
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 手机已确认
        /// </summary>  
        public bool PhoneNumberConfirmed { get; set; }
        /// <summary>
        /// 密码
        /// </summary>  
        public string Password { get; set; }
        /// <summary>
        /// 密码散列
        /// </summary>  
        public string PasswordHash { get; set; }
        /// <summary>
        /// 安全码
        /// </summary>  
        public string SafePassword { get; set; }
        /// <summary>
        /// 安全码散列
        /// </summary>  
        public string SafePasswordHash { get; set; }
        /// <summary>
        /// 启用两阶段认证
        /// </summary>  
        public bool TwoFactorEnabled { get; set; }
        /// <summary>
        /// 启用
        /// </summary>  
        public bool Enabled { get; set; }
        /// <summary>
        /// 冻结时间
        /// </summary>  
        public DateTime? DisabledTime { get; set; }
        /// <summary>
        /// 启用锁定
        /// </summary>  
        public bool LockoutEnabled { get; set; }
        /// <summary>
        /// 锁定截止
        /// </summary>  
        public DateTimeOffset? LockoutEnd { get; set; }
        /// <summary>
        /// 登录失败次数
        /// </summary>  
        public int? AccessFailedCount { get; set; }
        /// <summary>
        /// 登录次数
        /// </summary>  
        public int? LoginCount { get; set; }
        /// <summary>
        /// 注册Ip
        /// </summary>  
        public string RegisterIp { get; set; }
        /// <summary>
        /// 上次登陆时间
        /// </summary>  
        public DateTime? LastLoginTime { get; set; }
        /// <summary>
        /// 上次登陆Ip
        /// </summary>  
        public string LastLoginIp { get; set; }
        /// <summary>
        /// 本次登陆时间
        /// </summary>  
        public DateTime? CurrentLoginTime { get; set; }
        /// <summary>
        /// 本次登陆Ip
        /// </summary>  
        public string CurrentLoginIp { get; set; }
        /// <summary>
        /// 安全戳
        /// </summary>  
        public string SecurityStamp { get; set; }
        /// <summary>
        /// 备注
        /// </summary>  
        public string Remark { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>  
        public DateTime? CreationTime { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>  
        public Guid? CreatorId { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>  
        public DateTime? LastModificationTime { get; set; }
        /// <summary>
        /// 最后修改人
        /// </summary>  
        public Guid? LastModifierId { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>  
        public bool IsDeleted { get; set; }
    }
}