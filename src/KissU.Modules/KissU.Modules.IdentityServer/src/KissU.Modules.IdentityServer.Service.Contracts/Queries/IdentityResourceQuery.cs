// <copyright file="IdentityResourceQuery.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.IdentityServer.Service.Contracts.Queries
{
    using Util.Datas.Queries;

    /// <summary>
    /// 身份资源查询实体
    /// </summary>
    public class IdentityResourceQuery : QueryParameter
    {
        /// <summary>
        /// 启用状态
        /// </summary>
        [Display(Name = "启用状态")]
        public bool? Enabled { get; set; }
    }
}
