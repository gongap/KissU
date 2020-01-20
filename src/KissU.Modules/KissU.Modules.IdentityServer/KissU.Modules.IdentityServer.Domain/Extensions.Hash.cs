using System;
using System.Security.Cryptography;
using System.Text;

namespace KissU.Modules.IdentityServer.Domain
{
    /// <summary>
    /// 哈希字符串的扩展方法
    /// </summary>
    public static class HashExtensions
    {
        /// <summary>
        /// 创建指定输入的SHA256哈希。
        /// </summary>
        /// <param name="input">输入</param>
        /// <returns>散列</returns>
        public static string Sha256(this string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return string.Empty;

            using (var sha = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(input);
                var hash = sha.ComputeHash(bytes);

                return Convert.ToBase64String(hash);
            }
        }

        /// <summary>
        /// 创建指定输入的SHA256哈希.
        /// </summary>
        /// <param name="input">输入.</param>
        /// <returns>散列.</returns>
        public static byte[] Sha256(this byte[] input)
        {
            if (input == null) return null;

            using (var sha = SHA256.Create())
            {
                return sha.ComputeHash(input);
            }
        }

        /// <summary>
        /// 创建指定输入的SHA512哈希.
        /// </summary>
        /// <param name="input">输入.</param>
        /// <returns>散列</returns>
        public static string Sha512(this string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return string.Empty;

            using (var sha = SHA512.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(input);
                var hash = sha.ComputeHash(bytes);

                return Convert.ToBase64String(hash);
            }
        }
    }
}