using System.ComponentModel.DataAnnotations;
using KissU.Util.Domains;

namespace KissU.Modules.IdentityServer.Domain.Models
{
    /// <summary>
    /// 应用程序属性
    /// </summary>
    public class ClientProperty : Property
    {
        /// <summary>
        /// 应用程序
        /// </summary>
        public Client Client { get; set; }
    }
}