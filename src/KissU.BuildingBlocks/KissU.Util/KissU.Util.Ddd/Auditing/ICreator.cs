﻿namespace KissU.Util.Ddd.Domain.Auditing
{
    /// <summary>
    /// 创建人审计
    /// </summary>
    public interface ICreator
    {
        /// <summary>
        /// 创建人
        /// </summary>
        string Creator { get; set; }
    }
}