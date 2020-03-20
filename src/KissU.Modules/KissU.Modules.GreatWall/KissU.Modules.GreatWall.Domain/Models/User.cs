using System.ComponentModel.DataAnnotations.Schema;
using KissU.Core;
using KissU.Core.Exceptions;
using KissU.Core.Security.Encryptors;
using KissU.Core.Validations;
using KissU.Modules.GreatWall.Domain.Encryptors;

namespace KissU.Modules.GreatWall.Domain.Models
{
    /// <summary>
    /// 用户
    /// </summary>
    public partial class User
    {
        /// <summary>
        /// 加密器
        /// </summary>
        [NotMapped]
        public IEncryptor Encryptor { get; set; }

        /// <summary>
        /// 初始化
        /// </summary>
        public override void Init()
        {
            base.Init();
            InitUserName();
        }

        /// <summary>
        /// 初始化用户名
        /// </summary>
        private void InitUserName()
        {
            if (UserName.IsEmpty() == false)
                return;
            if (PhoneNumber.IsEmpty() == false)
            {
                UserName = PhoneNumber;
                return;
            }

            if (Email.IsEmpty() == false)
                UserName = Email;
        }

        /// <summary>
        /// 验证
        /// </summary>
        /// <returns>ValidationResultCollection.</returns>
        /// <exception cref="Warning"></exception>
        public override ValidationResultCollection Validate()
        {
            if (UserName.IsEmpty())
                throw new Warning(GreatWallResource.UserNameIsEmpty);
            return base.Validate();
        }

        /// <summary>
        /// 设置密码
        /// </summary>
        /// <param name="password">密码</param>
        /// <param name="storeOriginalPassword">是否存储原始密码</param>
        public void SetPassword(string password, bool? storeOriginalPassword)
        {
            if (storeOriginalPassword.SafeValue())
            {
                Password = GetEncryptor().Encrypt(password);
                return;
            }

            Password = null;
        }

        /// <summary>
        /// 获取加密器
        /// </summary>
        /// <returns>IEncryptor.</returns>
        protected virtual IEncryptor GetEncryptor()
        {
            return Encryptor ?? new PasswordEncryptor();
        }

        /// <summary>
        /// 设置安全码
        /// </summary>
        /// <param name="password">安全码</param>
        /// <param name="storeOriginalPassword">是否存储原始密码</param>
        public void SetSafePassword(string password, bool? storeOriginalPassword)
        {
            if (storeOriginalPassword.SafeValue())
            {
                SafePassword = GetEncryptor().Encrypt(password);
                return;
            }

            SafePassword = null;
        }

        /// <summary>
        /// 获取密码
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetPassword()
        {
            return GetEncryptor().Decrypt(Password);
        }

        /// <summary>
        /// 获取安全码
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetSafePassword()
        {
            return GetEncryptor().Decrypt(SafePassword);
        }
    }
}