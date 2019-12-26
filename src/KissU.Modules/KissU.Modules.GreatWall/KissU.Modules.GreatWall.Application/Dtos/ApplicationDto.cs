using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KissU.Modules.GreatWall.Domain.Models;
using KissU.Modules.GreatWall.Domain.Shared.Enums;
using KissU.Util;
using KissU.Util.Applications.Dtos;

namespace KissU.Modules.GreatWall.Application.Dtos {
    /// <summary>
    /// 应用程序参数
    /// </summary>
    public class ApplicationDto : DtoBase {
        /// <summary>
        /// 应用程序类型
        /// </summary>
        [Display( Name = "应用程序类型" )]
        public ApplicationType ApplicationType { get; set; }
        /// <summary>
        /// 应用程序类型
        /// </summary>
        [Display( Name = "应用程序类型" )]
        public string ApplicationTypeName => ApplicationType.Description();
        /// <summary>
        /// 应用程序编码
        /// </summary>
        [Required(ErrorMessage = "应用程序编码不能为空")]
        [StringLength( 60 )]
        [Display( Name = "应用程序编码" )]
        public string Code { get; set; }
        /// <summary>
        /// 应用程序名称
        /// </summary>
        [Required(ErrorMessage = "应用程序名称不能为空")]
        [StringLength( 200 )]
        [Display( Name = "应用程序名称" )]
        public string Name { get; set; }
        /// <summary>
        /// 启用
        /// </summary>
        [Display( Name = "启用" )]
        public bool? Enabled { get; set; }
        /// <summary>
        /// 启用注册
        /// </summary>
        [Display( Name = "启用注册" )]
        public bool? RegisterEnabled { get; set; }
        /// <summary>
        /// 允许的授权类型
        /// </summary>
        [Display( Name = "允许的授权类型" )]
        public GrantType AllowedGrantType { get; set; }
        /// <summary>
        /// 允许通过浏览器访问令牌
        /// </summary>
        [Display( Name = "允许通过浏览器访问令牌" )]
        public bool? AllowAccessTokensViaBrowser { get; set; }
        /// <summary>
        /// 允许的跨域来源
        /// </summary>
        [Display( Name = "允许的跨域来源" )]
        public List<string> AllowedCorsOrigins { get; set; }
        /// <summary>
        /// 需要同意
        /// </summary>
        [Display( Name = "需要同意" )]
        public bool? RequireConsent { get; set; }
        /// <summary>
        /// 需要客户端密钥
        /// </summary>
        [Display( Name = "需要客户端密钥" )]
        public bool? RequireClientSecret { get; set; }
        /// <summary>
        /// 客户端密钥列表
        /// </summary>
        public List<ClientSecret> ClientSecrets { get; set; }
        /// <summary>
        /// 认证重定向地址
        /// </summary>
        [Display( Name = "认证重定向地址" )]
        public string RedirectUri { get; set; }
        /// <summary>
        /// 注销重定向地址
        /// </summary>
        [Display( Name = "注销重定向地址" )]
        public string PostLogoutRedirectUri { get; set; }
        /// <summary>
        /// 允许的作用域
        /// </summary>
        [Display( Name = "允许的作用域" )]
        public List<string> AllowedScopes { get; set; }
        /// <summary>
        /// 访问令牌生命周期
        /// </summary>
        [Display( Name = "访问令牌生命周期" )]
        public int AccessTokenLifetime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [StringLength( 500 )]
        [Display( Name = "备注" )]
        public string Remark { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Display( Name = "创建时间" )]
        public DateTime? CreationTime { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [Display( Name = "创建人" )]
        public Guid? CreatorId { get; set; }
        /// <summary>
        /// 版本号
        /// </summary>
        [Display( Name = "版本号" )]
        public Byte[] Version { get; set; }
    }
}