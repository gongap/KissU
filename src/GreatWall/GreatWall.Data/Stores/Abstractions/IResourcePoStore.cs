﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GreatWall.Data.Pos;
using Util.Datas.Stores;

namespace GreatWall.Data.Stores.Abstractions  {
    /// <summary>
    /// 资源存储器
    /// </summary>
    public interface IResourcePoStore : IStore<ResourcePo> {
        /// <summary>
        /// 获取模块列表
        /// </summary>
        /// <param name="applicationId">应用程序标识</param>
        /// <param name="roleIds">角色标识列表</param>
        Task<List<ResourcePo>> GetModulesAsync( Guid applicationId, List<Guid> roleIds );
    }
}