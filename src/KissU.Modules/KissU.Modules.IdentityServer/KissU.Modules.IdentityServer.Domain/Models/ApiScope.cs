using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KissU.Util.Domains;

namespace KissU.Modules.IdentityServer.Domain.Models
{
    /// <summary>
    /// Api许可范围
    /// </summary>
    public class ApiScope : EntityBase<ApiScope, int>
    {
        /// <summary>
        /// 初始化Api许可范围
        /// </summary>
        public ApiScope() : base(default)
        {
            UserClaims = new List<ApiScopeClaim>();
        }

        /// <summary>
        /// Api资源
        /// </summary>
        public ApiResource ApiResource { get; set; }

        /// <summary>
        /// 应包含在身份令牌中的关联用户声明类型的列表。
        /// </summary>
        public List<ApiScopeClaim> UserClaims { get; set; }

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
        /// 指定用户是否可以在同意屏幕上取消选择范围（如果同意屏幕要实现此类功能）。默认为false。
        /// </summary>
        public bool Required { get; set; }

        /// <summary>
        /// 指定同意屏幕是否会强调此范围（如果同意屏幕要实现此类功能）。将此设置用于敏感或重要范围。默认为false。
        /// </summary>
        public bool Emphasize { get; set; }

        /// <summary>
        /// 指定此范围是否显示在发现文档中。默认为true。
        /// </summary>
        public bool ShowInDiscoveryDocument { get; set; } = true;
    }
}