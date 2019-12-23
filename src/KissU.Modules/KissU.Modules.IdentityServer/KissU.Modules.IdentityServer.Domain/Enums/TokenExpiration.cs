// <copyright file="TokenExpiration.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.IdentityServer.Domain.Enums
{
    /// <summary>
    /// Token expiration types.
    /// </summary>
    public enum TokenExpiration
    {
        /// <summary>
        /// Sliding token expiration
        /// </summary>
        Sliding = 0,

        /// <summary>
        /// Absolute token expiration
        /// </summary>
        Absolute = 1
    }
}
