using Microsoft.AspNetCore.Identity;

namespace KissU.Modules.GreatWall.Domain.Describers
{
    /// <summary>
    /// Identity中文错误描述
    /// </summary>
    public class IdentityErrorChineseDescriber : IdentityErrorDescriber
    {
        /// <summary>
        /// 密码太短
        /// </summary>
        /// <param name="length">The length that is not long enough.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.AspNetCore.Identity.IdentityError" /> indicating a password of the specified
        /// <paramref name="length" /> does not meet the minimum length requirements.
        /// </returns>
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError
            {
                Code = nameof(PasswordTooShort),
                Description = string.Format(GreatWallResource.PasswordTooShort, length)
            };
        }

        /// <summary>
        /// 密码应包含非字母和数字的特殊字符
        /// </summary>
        /// <returns>
        /// An <see cref="T:Microsoft.AspNetCore.Identity.IdentityError" /> indicating a password entered does not
        /// contain a non-alphanumeric character.
        /// </returns>
        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresNonAlphanumeric),
                Description = GreatWallResource.PasswordRequiresNonAlphanumeric
            };
        }

        /// <summary>
        /// 密码应包含大写字母
        /// </summary>
        /// <returns>
        /// An <see cref="T:Microsoft.AspNetCore.Identity.IdentityError" /> indicating a password entered does not
        /// contain an upper case letter.
        /// </returns>
        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresUpper),
                Description = GreatWallResource.PasswordRequiresUpper
            };
        }

        /// <summary>
        /// 密码应包含数字
        /// </summary>
        /// <returns>
        /// An <see cref="T:Microsoft.AspNetCore.Identity.IdentityError" /> indicating a password entered does not
        /// contain a numeric character.
        /// </returns>
        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresDigit),
                Description = GreatWallResource.PasswordRequiresDigit
            };
        }

        /// <summary>
        /// 密码应包含不重复的字符数
        /// </summary>
        /// <param name="uniqueChars">The number of different chars that must be used.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.AspNetCore.Identity.IdentityError" /> indicating a password does not meet the
        /// minimum number <paramref name="uniqueChars" /> of unique chars.
        /// </returns>
        public override IdentityError PasswordRequiresUniqueChars(int uniqueChars)
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresUniqueChars),
                Description = string.Format(GreatWallResource.PasswordRequiresUniqueChars, uniqueChars)
            };
        }

        /// <summary>
        /// 无效用户名
        /// </summary>
        /// <param name="userName">The user name that is invalid.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.AspNetCore.Identity.IdentityError" /> indicating the specified user
        /// <paramref name="userName" /> is invalid.
        /// </returns>
        public override IdentityError InvalidUserName(string userName)
        {
            return new IdentityError
            {
                Code = nameof(InvalidUserName),
                Description = string.Format(GreatWallResource.InvalidUserName, userName)
            };
        }

        /// <summary>
        /// 用户名重复
        /// </summary>
        /// <param name="userName">The user name that already exists.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.AspNetCore.Identity.IdentityError" /> indicating the specified
        /// <paramref name="userName" /> already exists.
        /// </returns>
        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError
            {
                Code = nameof(DuplicateUserName),
                Description = string.Format(GreatWallResource.DuplicateUserName, userName)
            };
        }

        /// <summary>
        /// 电子邮件重复
        /// </summary>
        /// <param name="email">The email that is already associated with an account.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.AspNetCore.Identity.IdentityError" /> indicating the specified
        /// <paramref name="email" /> is already associated with an account.
        /// </returns>
        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError
            {
                Code = nameof(DuplicateEmail),
                Description = string.Format(GreatWallResource.DuplicateEmail, email)
            };
        }

        /// <summary>
        /// 无效令牌
        /// </summary>
        /// <returns>An <see cref="T:Microsoft.AspNetCore.Identity.IdentityError" /> indicating an invalid token.</returns>
        public override IdentityError InvalidToken()
        {
            return new IdentityError
            {
                Code = nameof(InvalidToken),
                Description = GreatWallResource.InvalidToken
            };
        }

        /// <summary>
        /// 密码错误
        /// </summary>
        /// <returns>An <see cref="T:Microsoft.AspNetCore.Identity.IdentityError" /> indicating a password mismatch.</returns>
        public override IdentityError PasswordMismatch()
        {
            return new IdentityError
            {
                Code = nameof(PasswordMismatch),
                Description = GreatWallResource.PasswordMismatch
            };
        }

        /// <summary>
        /// 角色名无效
        /// </summary>
        /// <param name="role">The invalid role.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.AspNetCore.Identity.IdentityError" /> indicating the specific role
        /// <paramref name="role" /> name is invalid.
        /// </returns>
        public override IdentityError InvalidRoleName(string role)
        {
            return new IdentityError
            {
                Code = nameof(InvalidRoleName),
                Description = string.Format(GreatWallResource.InvalidRoleName, role)
            };
        }

        /// <summary>
        /// 角色名重复
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns>IdentityError.</returns>
        public override IdentityError DuplicateRoleName(string role)
        {
            return new IdentityError
            {
                Code = nameof(DuplicateRoleName),
                Description = string.Format(GreatWallResource.DuplicateRoleName, role)
            };
        }
    }
}