// <copyright file="Client.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using KissU.Util;
using KissU.Util.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Convert = KissU.Util.Helpers.Convert;

namespace KissU.Modules.IdentityServer.Domain.Models.ClientAggregate
{
    /// <summary>
    /// 应用程序
    /// </summary>
    [Description("应用程序")]
    public partial class Client
    {
        /// <summary>
        /// 初始化应用程序
        /// </summary>
        public Client() : this(Guid.Empty)
        {
        }

        /// <summary>
        /// 初始化应用程序
        /// </summary>
        /// <param name="id">应用程序标识</param>
        public Client(Guid id) : base(id)
        {
            ClientSecrets = new List<ClientSecret>();
            Claims = new List<ClientClaim>();
        }

        /// <summary>
        /// 应用程序密钥
        /// </summary>
        public List<ClientSecret> ClientSecrets { get; set; }

        /// <summary>
        /// 应用程序声明
        /// </summary>
        public List<ClientClaim> Claims { get; set; }

        /// <summary>
        /// 应用程序属性
        /// </summary>
        [NotMapped]
        public List<ClientProperty> Properties
        {
            get => Json.ToObject<List<ClientProperty>>(ClientProperties);
            set => ClientProperties = Json.ToJson(value);
        }

        /// <summary>
        /// 指定允许应用程序使用的授权类型。将该GrantTypes类用于常见组合。
        /// </summary>
        [NotMapped]
        public List<string> AllowedGrantTypes
        {
            get => Convert.ToList<string>(ClientAllowedGrantTypes);
            set => ClientAllowedGrantTypes = value.Join();
        }

        /// <summary>
        /// 指定允许的URI以返回令牌或授权码
        /// </summary>
        [NotMapped]
        public List<string> RedirectUris
        {
            get => Convert.ToList<string>(ClientRedirectUris);
            set => ClientRedirectUris = value.Join();
        }

        /// <summary>
        /// 默认情况下，应用程序无权访问任何资源 - 通过添加相应的范围名称来指定允许的资源
        /// </summary>
        [NotMapped]
        public List<string> AllowedScopes
        {
            get => Convert.ToList<string>(ClientAllowedScopes);
            set => ClientAllowedScopes = value.Join();
        }

        /// <summary>
        /// 指定在注销后重定向到的允许URI。有关更多详细信息，请参阅OIDC Connect会话管理规范。
        /// </summary>
        [NotMapped]
        public List<string> PostLogoutRedirectUris
        {
            get => Convert.ToList<string>(ClientPostLogoutRedirectUris);
            set => ClientPostLogoutRedirectUris = value.Join();
        }

        /// <summary>
        /// 指定可以与此应用程序一起使用的外部IdP（如果列表为空，则允许所有IdP）。默认为空。
        /// </summary>
        [NotMapped]
        public List<string> IdentityProviderRestrictions
        {
            get => Convert.ToList<string>(ClientIdentityProviderRestrictions);
            set => ClientIdentityProviderRestrictions = value.Join();
        }

        /// <summary>
        /// 如果指定，将由默认CORS策略服务实现（内存和EF）用于为JavaScript应用程序构建CORS策略。
        /// </summary>
        [NotMapped]
        public List<string> AllowedCorsOrigins
        {
            get => Convert.ToList<string>(ClientAllowedCorsOrigins);
            set => ClientAllowedCorsOrigins = value.Join();
        }
    }
}
