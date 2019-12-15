// <copyright file="ClientQuery.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.IdentityServer.Service.Contracts.Queries
{
    using System.ComponentModel.DataAnnotations;
    using Util.Datas.Queries;

    /// <summary>
    /// 应用程序查询实体
    /// </summary>
    public class ClientQuery : QueryParameter
    {
        /// <summary>
        /// 启用状态
        /// </summary>
        [Display(Name = "启用状态")]
        public bool? Enabled { get; set; }
    }
}
