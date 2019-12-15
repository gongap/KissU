// <copyright file="EventLogDto.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.IdentityServer.Service.Contracts.Dtos
{
    using System;
    using Util.Applications.Dtos;

    /// <summary>
    /// 授权日志传输对象
    /// </summary>
    public class EventLogDto : DtoBase
    {
        public int EventId { get; set; }

        public int ProcessId { get; set; }

        public string ActivityId { get; set; }

        public string Category { get; set; }

        public string Name { get; set; }

        public string Message { get; set; }

        public string Username { get; set; }

        public string Provider { get; set; }

        public string ProviderUserId { get; set; }

        public string SubjectId { get; set; }

        public string DisplayName { get; set; }

        public string ClientId { get; set; }

        public string ClientName { get; set; }

        public string TokenType { get; set; }

        public string Token { get; set; }

        public string RedirectUri { get; set; }

        public string Endpoint { get; set; }

        public string Scopes { get; set; }

        public string GrantType { get; set; }

        public string AuthenticationMethod { get; set; }

        public string ApiName { get; set; }

        public bool IsActive { get; set; }

        public bool ConsentRemembered { get; set; }

        public string Error { get; set; }

        public string ErrorDescription { get; set; }

        public string Details { get; set; }

        public string LocalIpAddress { get; set; }

        public string RemoteIpAddress { get; set; }

        public string Host { get; set; }

        public string Url { get; set; }

        public string Browser { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
