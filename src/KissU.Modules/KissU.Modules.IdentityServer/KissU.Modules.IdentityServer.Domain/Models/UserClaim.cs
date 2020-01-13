using System.ComponentModel.DataAnnotations;
using KissU.Util.Domains;

namespace KissU.Modules.IdentityServer.Domain.Models
{
    /// <summary>
    /// 用户声明
    /// </summary>
    public class UserClaim<T> : ValueObjectBase<UserClaim<T>>
    {
        /// <summary>
        /// 拥有者
        /// </summary>
        public T Owner { get; }

        /// <summary>
        /// 声明类型
        /// </summary>
        [StringLength(200)]
        public string Type { get; set; }
    }
}