// <copyright file="Extensions.IdentityResult.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using KissU.Util.Exceptions;
using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace KissU.Modules.GreatWall.Domain.Shared.Extensions
{
    /// <summary>
    /// Identity结果扩展
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// 失败抛出异常
        /// </summary>
        /// <param name="result">Identity结果</param>
        public static void ThrowIfError(this IdentityResult result)
        {
            if (result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }

            if (result.Succeeded == false)
            {
                throw new Warning(result.Errors.First().Description);
            }
        }
    }
}
