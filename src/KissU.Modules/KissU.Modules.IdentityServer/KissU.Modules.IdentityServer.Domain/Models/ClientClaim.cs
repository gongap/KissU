using System.ComponentModel.DataAnnotations;
using KissU.Core.Domains;

namespace KissU.Modules.IdentityServer.Domain.Models
{
    /// <summary>
    /// 应用程序声明
    /// </summary>
    public class ClientClaim : EntityBase<ClientClaim, int>
    {
        /// <summary>
        /// 初始化应用程序声明
        /// </summary>
        public ClientClaim() : base(default)
        {
        }

        /// <summary>
        /// 应用程序
        /// </summary>
        public Client Client { get; set; }

        /// <summary>
        /// 声明的类型
        /// </summary>
        [Required]
        [StringLength(250)]
        public string Type { get; set; }

        /// <summary>
        /// 声明的值
        /// </summary>
        [Required]
        [StringLength(250)]
        public string Value { get; set; }
    }
}