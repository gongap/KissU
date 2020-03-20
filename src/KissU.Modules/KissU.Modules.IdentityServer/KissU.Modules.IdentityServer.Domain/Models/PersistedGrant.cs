using System;
using System.ComponentModel.DataAnnotations;
using KissU.Core.Domains;

namespace KissU.Modules.IdentityServer.Domain.Models
{
    /// <summary>
    /// 认证操作数据（令牌，代码和同意书）
    /// </summary>
    public class PersistedGrant : AggregateRoot<PersistedGrant, int>
    {
        /// <summary>
        /// 初始化认证操作数据
        /// </summary>
        public PersistedGrant() : base(default)
        {
        }

        /// <summary>
        /// 标识
        /// </summary>
        [Required]
        [StringLength(200)]
        public string Key { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        /// <summary>
        /// 主体
        /// </summary>
        [StringLength(200)]
        public string SubjectId { get; set; }

        /// <summary>
        /// 应用程序编号
        /// </summary>
        [Required]
        [StringLength(200)]
        public string ClientId { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        [Required]
        [StringLength(50000)]
        public string Data { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// 到期时间
        /// </summary>
        public DateTime? Expiration { get; set; }
    }
}