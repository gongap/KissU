// <copyright file="SignInState.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.GreatWall.Domain.Shared.Results
{
    /// <summary>
    /// 登录状态
    /// </summary>
    public enum SignInState
    {
        /// <summary>
        /// 登录成功
        /// </summary>
        Succeeded,

        /// <summary>
        /// 失败
        /// </summary>
        Failed,

        /// <summary>
        /// 需要两步认证
        /// </summary>
        TwoFactor
    }
}
