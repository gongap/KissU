// <copyright file="ThemeUnitOfWork.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.Theme.Data.UnitOfWorks.SqlServer
{
    using Microsoft.EntityFrameworkCore;
    using Util.Datas.Ef.SqlServer;
    using Util.Reflections;

    /// <summary>
    /// SqlServer工作单元
    /// </summary>
    public class ThemeUnitOfWork : UnitOfWork, IThemeUnitOfWork
    {
        /// <summary>
        /// 类型查找器
        /// </summary>
        protected readonly IFind Finder;

        /// <summary>
        /// 初始化工作单元
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="finder">类型查找器</param>
        public ThemeUnitOfWork(DbContextOptions<ThemeUnitOfWork> options, IFind finder = null) : base(options)
        {
            Finder = finder ?? new Finder();
        }
    }
}
