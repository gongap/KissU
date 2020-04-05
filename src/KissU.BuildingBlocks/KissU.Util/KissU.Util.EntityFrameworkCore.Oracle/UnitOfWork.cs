using System;
using System.Collections.Generic;
using System.Reflection;
using KissU.Core.Helpers;
using KissU.Util.Datas.Ef.Core;
using KissU.Util.Datas.Ef.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace KissU.Util.Datas.Oracle.Ef
{
    /// <summary>
    /// Oracle工作单元
    /// </summary>
    public abstract class UnitOfWork : UnitOfWorkBase
    {
        /// <summary>
        /// 初始化Oracle工作单元
        /// </summary>
        /// <param name="options">配置</param>
        /// <param name="serviceProvider">服务提供器</param>
        protected UnitOfWork(DbContextOptions options, IServiceProvider serviceProvider = null)
            : base(options, serviceProvider)
        {
        }

        /// <summary>
        /// 获取映射实例列表
        /// </summary>
        /// <param name="assembly">程序集</param>
        /// <returns>IEnumerable&lt;IMap&gt;.</returns>
        protected override IEnumerable<Datas.Ef.Core.IMap> GetMapInstances(Assembly assembly)
        {
            return Reflection.GetInstancesByInterface<IMap>(assembly);
        }

        /// <summary>
        /// 拦截添加操作
        /// </summary>
        /// <param name="entry">The entry.</param>
        protected override void InterceptAddedOperation(EntityEntry entry)
        {
            base.InterceptAddedOperation(entry);
            Helper.InitVersion(entry);
        }

        /// <summary>
        /// 拦截修改操作
        /// </summary>
        /// <param name="entry">The entry.</param>
        protected override void InterceptModifiedOperation(EntityEntry entry)
        {
            base.InterceptModifiedOperation(entry);
            Helper.InitVersion(entry);
        }
    }
}