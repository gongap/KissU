﻿using System;
using System.Collections.Generic;
using System.Reflection;
using KissU.Util.Datas.Ef.Core;
using Microsoft.EntityFrameworkCore;

namespace KissU.Util.Datas.SqlServer.Ef
{
    /// <summary>
    /// SqlServer工作单元
    /// </summary>
    public abstract class UnitOfWork : UnitOfWorkBase
    {
        /// <summary>
        /// 初始化SqlServer工作单元
        /// </summary>
        /// <param name="options">配置</param>
        /// <param name="serviceProvider">服务提供器</param>
        protected UnitOfWork( DbContextOptions options, IServiceProvider serviceProvider = null )
            : base( options, serviceProvider )
            {
        }

        /// <summary>
        /// 获取映射实例列表
        /// </summary>
        /// <param name="assembly">程序集</param>
        protected override IEnumerable<Datas.Ef.Core.IMap> GetMapInstances( Assembly assembly )
        {
            return Util.Helpers.Reflection.GetInstancesByInterface<IMap>( assembly );
        }
    }
}
