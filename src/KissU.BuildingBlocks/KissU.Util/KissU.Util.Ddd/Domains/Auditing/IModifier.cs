﻿namespace KissU.Util.Ddd.Domain.Domains.Auditing
{
    /// <summary>
    /// 修改人审计
    /// </summary>
    public interface IModifier
    {
        /// <summary>
        /// 最后修改人
        /// </summary>
        string Modifier { get; set; }
    }
}