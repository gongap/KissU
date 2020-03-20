using KissU.Core.Security.Encryptors;

namespace KissU.Modules.GreatWall.Domain.Encryptors
{
    /// <summary>
    /// 密码加密器
    /// </summary>
    public class PasswordEncryptor : IEncryptor
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="data">原始数据</param>
        /// <returns>System.String.</returns>
        public string Encrypt(string data)
        {
            return Core.Helpers.Encrypt.AesEncrypt(data);
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="data">已加密数据</param>
        /// <returns>System.String.</returns>
        public string Decrypt(string data)
        {
            return Core.Helpers.Encrypt.AesDecrypt(data);
        }
    }
}