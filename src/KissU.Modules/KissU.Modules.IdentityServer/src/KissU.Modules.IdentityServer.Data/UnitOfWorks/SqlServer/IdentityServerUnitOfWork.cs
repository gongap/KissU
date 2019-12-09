// <copyright file="IdentityServerUnitOfWork.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.IdentityServer.Data.UnitOfWorks.SqlServer
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using Util.Datas.Ef.SqlServer;
    using Util.Domains;
    using Util.Reflections;

    /// <summary>
    ///     工作单元
    /// </summary>
    public class IdentityServerUnitOfWork : UnitOfWork, IIdentityServerUnitOfWork
    {
        /// <summary>
        ///     类型查找器
        /// </summary>
        protected readonly IFind Finder;

        /// <summary>
        ///     初始化工作单元
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="serviceProvider">服务提供器</param>
        /// <param name="finder">类型查找器</param>
        public IdentityServerUnitOfWork(DbContextOptions<IdentityServerUnitOfWork> options,
            IServiceProvider serviceProvider = null, IFind finder = null) : base(options, serviceProvider)
        {
            Finder = finder ?? new Finder();
        }

        /// <summary>
        ///     配置映射
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigureFilters(modelBuilder);
        }

        /// <summary>
        ///     拦截添加操作
        /// </summary>
        protected override void InterceptAddedOperation(EntityEntry entry)
        {
            base.InterceptAddedOperation(entry);
        }

        /// <summary>
        ///     拦截删除操作
        /// </summary>
        /// <param name="entry"></param>
        protected override void InterceptDeletedOperation(EntityEntry entry)
        {
            base.InterceptDeletedOperation(entry);
            AddStaticIntercept(entry.Entity);
        }

        /// <summary>
        ///     拦截更新操作
        /// </summary>
        /// <param name="entry"></param>
        protected override void InterceptModifiedOperation(EntityEntry entry)
        {
            base.InterceptModifiedOperation(entry);
            if (entry.Entity is IDelete model && model.IsDeleted)
            {
                AddStaticIntercept(entry.Entity);
            }
        }

        /// <summary>
        ///     添加系统内置静态资源拦截器
        /// </summary>
        protected virtual void AddStaticIntercept(object entity)
        {
        }

        /// <summary>
        ///     配置过滤条件
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected virtual void ConfigureFilters(ModelBuilder modelBuilder)
        {
        }
    }
}
