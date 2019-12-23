// <copyright file="ClientType.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.IdentityServer.Domain.Enums
{
    public enum ClientType
    {
        Empty = 0,
        WebImplicit = 1,
        WebHybrid = 2,
        Spa = 3,
        Native = 4,
        Machine = 5
    }
}
