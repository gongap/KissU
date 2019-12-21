﻿// <copyright file="ClientDto.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KissU.Util.Applications.Dtos;

namespace KissU.Modules.IdentityServer.Application.Dtos
{
    /// <summary>
    /// 应用程序数据传输对象
    /// </summary>
    public class ClientDto : DtoBase
    {
        /// <summary>
        /// 版本号
        /// </summary>

        [Display(Name = "版本号")]
        public byte[] Version { get; set; }

        #region 名称

        /// <summary>
        /// 应用程序唯一编码
        /// </summary>

        [Required]
        [StringLength(60, ErrorMessage = "应用程序唯一编码输入过长，不能超过60位")]
        [Display(Name = "应用程序唯一编码")]
        public string ClientId { get; set; }

        /// <summary>
        /// 应用程序显示名称
        /// </summary>

        [StringLength(200, ErrorMessage = "应用程序显示名称输入过长，不能超过200位")]
        [Display(Name = "应用程序显示名称")]
        public string ClientName { get; set; }

        #endregion

        #region 基础信息

        /// <summary>
        /// 指定是否启用应用程序。默认为true。
        /// </summary>

        [Required]
        [Display(Name = "是否启用应用程序")]
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// 应用程序的描述
        /// </summary>

        [Display(Name = "应用程序的描述")]
        [StringLength(1000, ErrorMessage = "应用程序显示名称输入过长，不能超过1000位")]
        public string Description { get; set; }

        /// <summary>
        /// 协议类型
        /// </summary>

        [Required]
        [StringLength(200, ErrorMessage = "协议类型输入过长，不能超过200位")]
        [Display(Name = "协议类型")]
        public string ProtocolType { get; set; }

        /// <summary>
        /// 应用程序密钥列表
        /// </summary>

        [Display(Name = "应用程序密钥列表")]
        public List<ClientSecretDto> ClientSecrets { get; set; }

        /// <summary>
        /// 指定此应用程序是否需要密钥才能从令牌端点请求令牌（默认为true）
        /// </summary>

        [Required]
        [Display(Name = "是否需要密钥才能从令牌端点请求令牌")]
        public bool RequireClientSecret { get; set; } = true;

        /// <summary>
        /// 指定允许应用程序使用的授权类型。将该GrantTypes类用于常见组合。
        /// </summary>

        [Display(Name = "允许应用程序使用的授权类型")]
        public List<string> AllowedGrantTypes { get; set; }

        /// <summary>
        /// 指定使用基于授权代码的授权类型的应用程序是否必须发送校验密钥
        /// </summary>

        [Required]
        [Display(Name = "是否必须发送校验密钥")]
        public bool RequirePkce { get; set; }

        /// <summary>
        /// 指定使用PKCE的应用程序是否可以使用纯文本代码质询（不推荐 - 默认为false）
        /// </summary>

        [Required]
        [Display(Name = "是否可以使用纯文本代码质询")]
        public bool AllowPlainTextPkce { get; set; }

        /// <summary>
        /// 指定允许的URI以返回令牌或授权码
        /// </summary>

        [Display(Name = "允许的URI以返回令牌或授权码")]
        public List<string> RedirectUris { get; set; }

        /// <summary>
        /// 默认情况下，应用程序无权访问任何资源 - 通过添加相应的范围名称来指定允许的资源
        /// </summary>

        [Display(Name = "允许的资源范围")]
        public List<string> AllowedScopes { get; set; }

        /// <summary>
        /// 指定此应用程序是否可以请求刷新令牌（请求offline_access范围）
        /// </summary>

        [Required]
        [Display(Name = "是否可以请求刷新令牌")]
        public bool AllowOfflineAccess { get; set; }

        /// <summary>
        /// 指定是否允许此应用程序通过浏览器接收访问令牌。这对于强化允许多种响应类型的流是有用的（例如，通过禁止混合流应用程序，该应用程序应该使用代码id_token来添加令牌响应类型，从而将令牌泄露给浏览器。
        /// </summary>

        [Required]
        [Display(Name = "是否允许此应用程序通过浏览器接收访问令牌")]
        public bool AllowAccessTokensViaBrowser { get; set; }

        /// <summary>
        /// 字典可根据需要保存任何自定义应用程序特定值。
        /// </summary>

        [Display(Name = "属性")]
        public IDictionary<string, string> Properties { get; set; }

        #endregion

        #region 认证/注销

        /// <summary>
        /// 指定在注销后重定向到的允许URI。有关更多详细信息，请参阅OIDC Connect会话管理规范。
        /// </summary>

        [Display(Name = "注销后重定向到的允许URI")]
        public List<string> PostLogoutRedirectUris { get; set; }

        /// <summary>
        /// 指定应用程序的注销URI，以用于基于HTTP的前端通道注销。有关详细信息，请参阅OIDC Front-Channel规范。
        /// </summary>

        [StringLength(2000, ErrorMessage = "前端通道注销URI输入过长，不能超过2000位")]
        [Display(Name = "前端通道注销URI")]
        public string FrontChannelLogoutUri { get; set; }

        /// <summary>
        /// 指定是否应将用户的会话ID发送到FrontChannelLogoutUri。默认为true。
        /// </summary>

        [Required]
        [Display(Name = "是否应将用户的会话ID发送到FrontChannelLogoutUri")]
        public bool FrontChannelLogoutSessionRequired { get; set; } = true;

        /// <summary>
        /// 指定应用程序的注销URI，以用于基于HTTP的反向通道注销。有关详细信息，请参阅OIDC Back-Channel规范。
        /// </summary>

        [StringLength(2000, ErrorMessage = "反向通道注销Uri输入过长，不能超过2000位")]
        [Display(Name = "反向通道注销Uri")]
        public string BackChannelLogoutUri { get; set; }

        /// <summary>
        /// 指定是否应在请求中将用户的会话ID发送到BackChannelLogoutUri。默认为true。
        /// </summary>

        [Required]
        [Display(Name = "否应在请求中将用户的会话ID发送到BackChannelLogoutUri")]
        public bool BackChannelLogoutSessionRequired { get; set; } = true;

        /// <summary>
        /// 指定此应用程序是否可以仅使用本地帐户或外部IdP。默认为true。
        /// </summary>

        [Required]
        [Display(Name = "是否可以仅使用本地帐户或外部IdP")]
        public bool EnableLocalLogin { get; set; } = true;

        /// <summary>
        /// 指定可以与此应用程序一起使用的外部IdP（如果列表为空，则允许所有IdP）。默认为空。
        /// </summary>

        [Display(Name = "外部IdP")]
        public List<string> IdentityProviderRestrictions { get; set; }

        #endregion

        #region 令牌

        /// <summary>
        /// 标识令牌的生命周期（以秒为单位）（默认为300秒/ 5分钟）
        /// </summary>

        [Required]
        [Display(Name = "标识令牌的生命周期")]
        public int IdentityTokenLifetime { get; set; } = 300;

        /// <summary>
        /// 访问令牌的生命周期（以秒为单位）（默认为3600秒/ 1小时）
        /// </summary>

        [Required]
        [Display(Name = "访问令牌的生命周期")]
        public int AccessTokenLifetime { get; set; } = 3600;

        /// <summary>
        /// 授权代码的生命周期（以秒为单位）（默认为300秒/ 5分钟）
        /// </summary>

        [Required]
        [Display(Name = "授权代码的生命周期")]
        public int AuthorizationCodeLifetime { get; set; } = 300;

        /// <summary>
        /// 刷新令牌的最长生命周期，以秒为单位。默认为2592000秒/ 30天
        /// </summary>

        [Required]
        [Display(Name = "刷新令牌的最长生命周期")]
        public int AbsoluteRefreshTokenLifetime { get; set; } = 2592000;

        /// <summary>
        /// 刷新令牌的生命周期以秒为单位。默认为1296000秒/ 15天
        /// </summary>

        [Required]
        [Display(Name = "刷新令牌的生命周期以秒为单位")]
        public int SlidingRefreshTokenLifetime { get; set; } = 1296000;

        /// <summary>
        /// ReUse 刷新令牌时刷新令牌句柄将保持不变
        /// OneTime刷新令牌时将更新刷新令牌句柄。这是默认值。
        /// </summary>

        [Required]
        [Display(Name = "刷新令牌时将更新刷新令牌")]
        public int RefreshTokenUsage { get; set; }

        /// <summary>
        /// Absolute 刷新令牌将在固定时间点到期（由AbsoluteRefreshTokenLifetime指定）
        /// Sliding刷新令牌时，将刷新刷新令牌的生命周期（按SlidingRefreshTokenLifetime中指定的数量）。生命周期不会超过AbsoluteRefreshTokenLifetime。
        /// </summary>

        [Required]
        [Display(Name = "刷新刷新令牌的生命周期")]
        public int RefreshTokenExpiration { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否应在刷新令牌请求上更新访问令牌（及其声明）。
        /// </summary>

        [Required]
        [Display(Name = "是否应在刷新令牌请求上更新访问令牌")]
        public bool UpdateAccessTokenClaimsOnRefresh { get; set; }

        /// <summary>
        /// 指定访问令牌是引用令牌还是自包含JWT令牌（默认为Jwt）。AccessTokenType.Jwt
        /// </summary>

        [Required]
        [Display(Name = "引用令牌还是自包含JWT令牌")]
        public int AccessTokenType { get; set; } = 0;

        /// <summary>
        /// 指定JWT访问令牌是否应具有嵌入的唯一ID（通过jti声明）。
        /// </summary>

        [Required]
        [Display(Name = "JWT访问令牌是否应具有嵌入的唯一ID")]
        public bool IncludeJwtId { get; set; }

        /// <summary>
        /// 如果指定，将由默认CORS策略服务实现（内存和EF）用于为JavaScript应用程序构建CORS策略。
        /// </summary>

        [Display(Name = "CORS策略")]
        public List<string> AllowedCorsOrigins { get; set; }

        /// <summary>
        /// 允许应用程序的设置声明（将包含在访问令牌中）。
        /// </summary>
        //public List<ClientClaim> Claims { get; set; }
        /// <summary>
        /// 如果设置，将为每个流发送应用程序声明。如果不是，仅用于应用程序凭证流（默认为false）
        /// </summary>

        [Required]
        [Display(Name = "发送应用程序声明")]
        public bool AlwaysSendClientClaims { get; set; }

        /// <summary>
        /// 在请求id令牌和访问令牌时，如果用户声明始终将其添加到id令牌而不是请求应用程序使用userinfo端点。默认值为false。
        /// </summary>

        [Display(Name = "用户声明始终将其添加到id令牌")]
        public bool AlwaysIncludeUserClaimsInIdToken { get; set; }

        /// <summary>
        /// 如果设置，前缀应用程序声明类型将以前缀为。默认为client_。目的是确保它们不会意外地与用户声明冲突。
        /// </summary>

        [StringLength(200, ErrorMessage = "应用程序声明类型前缀输入过长，不能超过200位")]
        [Display(Name = "应用程序声明类型前缀")]
        public string ClientClaimsPrefix { get; set; } = "client_";

        /// <summary>
        /// 对于此应用程序的用户，在成对的subjectId生成中使用的salt值。
        /// </summary>

        [StringLength(200, ErrorMessage = "使用的salt值输入过长，不能超过200位")]
        [Display(Name = "使用的salt值")]
        public string PairWiseSubjectSalt { get; set; }

        #endregion

        #region 同意屏幕

        /// <summary>
        /// 指定是否需要同意屏幕。默认为true。
        /// </summary>

        [Display(Name = "是否需要同意屏幕")]
        public bool RequireConsent { get; set; } = true;

        /// <summary>
        /// 指定用户是否可以选择存储同意决策。默认为true。
        /// </summary>

        [Display(Name = "是否可以选择存储同意决策")]
        public bool AllowRememberConsent { get; set; } = true;

        /// <summary>
        /// 用户同意的生命周期，以秒为单位。默认为null（无到期）。
        /// </summary>

        [Display(Name = "用户同意的生命周期")]
        public int? ConsentLifetime { get; set; } = null;

        /// <summary>
        /// 有关应用程序的更多信息的URI（在同意屏幕上使用）
        /// </summary>

        [StringLength(2000, ErrorMessage = "使用的salt值输入过长，不能超过2000位")]
        [Display(Name = "有关应用程序的更多信息的URI")]
        public string ClientUri { get; set; }

        /// <summary>
        /// URI到应用程序徽标（在同意屏幕上使用）
        /// </summary>

        [StringLength(2000, ErrorMessage = "URI到应用程序徽标输入过长，不能超过2000位")]
        [Display(Name = "URI到应用程序徽标")]
        public string LogoUri { get; set; }

        #endregion
    }
}
