// <copyright file="DesignTimeDbContext.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using System.Reflection;
using KissU.Modules.GreatWall.Data;
using Microsoft.EntityFrameworkCore;
using KissU.Util.Datas.Ef.SqlServer;
using KissU.Util.Reflections;

namespace KissU.Modules.GreatWall.DbMigrator
{
    /// <summary>
    /// 此DbContext仅用于数据库迁移。
    /// </summary>
    public class DesignTimeDbContext : UnitOfWork, IGreatWallUnitOfWork
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
        public DesignTimeDbContext(DbContextOptions<DesignTimeDbContext> options, IFind finder = null) : base(options)
        {
            Finder = finder ?? new Finder();
        }

        /// <summary>
        /// 获取定义映射配置的程序集列表
        /// </summary>
        protected override Assembly[] GetAssemblies()
        {
            return Finder.GetAssemblies().ToArray();
        }
    }
}
