// <copyright file="ClientProperty.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using KissU.Util.Domains;

namespace KissU.Modules.IdentityServer.Domain.Models.ClientAggregate
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// 应用程序属性
    /// </summary>
    [Description("应用程序属性")]
    public class ClientProperty : DomainBase<ClientProperty>
    {
        /// <summary>
        /// 键
        /// </summary>
        [StringLength(250, ErrorMessage = "键输入过长，不能超过250位")]
        [DisplayName("键")]
        public string Key { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        [StringLength(2000, ErrorMessage = "值输入过长，不能超过2000位")]
        [DisplayName("值")]
        public string Value { get; set; }
    }
}
