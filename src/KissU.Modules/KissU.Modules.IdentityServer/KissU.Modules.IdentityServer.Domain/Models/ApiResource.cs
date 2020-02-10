using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KissU.Util.Domains;

namespace KissU.Modules.IdentityServer.Domain.Models
{
    /// <summary>
    /// Api资源
    /// </summary>
    public class ApiResource : AggregateRoot<ApiResource, int>
    {
        /// <summary>
        /// 初始Api资源
        /// </summary>
        public ApiResource() : base(default)
        {
            ApiSecrets = new List<ApiSecret>();
            Scopes = new List<ApiScope>();
            UserClaims = new List<ApiResourceClaim>();
            Properties = new List<ApiResourceProperty>();
        }

        /// <summary>
        /// API密钥列表
        /// </summary>
        public List<ApiSecret> ApiSecrets { get; set; }

        /// <summary>
        /// API必须至少有一个范围。每个范围可以有不同的设置。
        /// </summary>
        public List<ApiScope> Scopes { get; set; }

        /// <summary>
        /// 应包含在身份令牌中的关联用户声明类型的列表。
        /// </summary>
        public List<ApiResourceClaim> UserClaims { get; set; }

        /// <summary>
        /// 指示此资源是否已启用且可以请求。默认为true。
        /// </summary>
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// API的唯一名称。此值用于内省身份验证，并将添加到传出访问令牌的受众。
        /// </summary>
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        /// <summary>
        /// 显示名称。该值可以在例如同意屏幕上使用。
        /// </summary>
        [StringLength(200)]
        public string DisplayName { get; set; }

        /// <summary>
        /// 描述。该值可以在例如同意屏幕上使用。
        /// </summary>
        [StringLength(1000)]
        public string Description { get; set; }

        /// <summary>
        /// 属性
        /// </summary>
        public List<ApiResourceProperty> Properties { get; set; }
    }
}