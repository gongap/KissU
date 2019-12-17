// <copyright file="ThemeUnitOfWork.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using KissU.Util.Datas.SqlServer.Ef;
using Microsoft.EntityFrameworkCore;
using KissU.Util.Reflections;

namespace KissU.Modules.Theme.Data.UnitOfWorks.SqlServer
{
    /// <summary>
    /// SqlServer工作单元
    /// </summary>
    public class ThemeUnitOfWork : UnitOfWork, IThemeUnitOfWork
    {
        /// <summary>
        /// 初始化工作单元
        /// </summary>
        /// <param name="options">配置项</param>
        public ThemeUnitOfWork(DbContextOptions<ThemeUnitOfWork> options) : base(options)
        {
        }
    }
}
