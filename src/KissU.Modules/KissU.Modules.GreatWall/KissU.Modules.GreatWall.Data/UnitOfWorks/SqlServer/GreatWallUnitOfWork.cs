// <copyright file="GreatWallUnitOfWork.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using KissU.Util.Datas.SqlServer.Ef;
using Microsoft.EntityFrameworkCore;
using KissU.Util.Reflections;

namespace KissU.Modules.GreatWall.Data.UnitOfWorks.SqlServer
{
    /// <summary>
    /// SqlServer工作单元
    /// </summary>
    public class GreatWallUnitOfWork : UnitOfWork, IGreatWallUnitOfWork
    {
        /// <summary>
        /// 初始化工作单元
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="finder">类型查找器</param>
        public GreatWallUnitOfWork(DbContextOptions<GreatWallUnitOfWork> options) : base(options)
        {
        }
    }
}
