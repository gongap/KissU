﻿using System.ComponentModel.DataAnnotations;
using KissU.Util.Domains;

namespace KissU.Modules.IdentityServer.Domain.Models
{
    /// <summary>
    /// 外部IdP
    /// </summary>
    public class ClientIdPRestriction : ValueObjectBase<ClientIdPRestriction>
    {
        /// <summary>
        /// 提供程序
        /// </summary>
        [Required]
        [StringLength(200)]
        public string Provider { get; set; }
    }
}