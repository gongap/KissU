using System;
using System.Linq;
using KissU.Util.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace KissU.Modules.GreatWall.Domain.Extensions
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
        /// <exception cref="ArgumentNullException">result</exception>
        /// <exception cref="Warning"></exception>
        public static void ThrowIfError(this IdentityResult result)
        {
            if (result == null)
                throw new ArgumentNullException(nameof(result));
            if (result.Succeeded == false)
                throw new Warning(result.Errors.First().Description);
        }
    }
}