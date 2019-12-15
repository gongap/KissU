// <copyright file="GreatWallUnitOfWork.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.GreatWall.Data.UnitOfWorks.SqlServer
{
    using Microsoft.EntityFrameworkCore;
    using Util.Datas.Ef.SqlServer;
    using Util.Reflections;

    /// <summary>
    /// SqlServer工作单元
    /// </summary>
    public class GreatWallUnitOfWork : UnitOfWork, IGreatWallUnitOfWork
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
        public GreatWallUnitOfWork(DbContextOptions<GreatWallUnitOfWork> options, IFind finder = null) : base(options)
        {
            Finder = finder ?? new Finder();
        }
    }
}
