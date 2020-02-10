using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Modules.GreatWall.Domain.Models;
using KissU.Util.Domains.Trees;

namespace KissU.Modules.GreatWall.Domain.Repositories
{
    /// <summary>
    /// 模块仓储
    /// </summary>
    public interface IModuleRepository : ITreeCompactRepository<Module>
    {
        /// <summary>
        /// 生成排序号
        /// </summary>
        /// <param name="applicationId">应用程序标识</param>
        /// <param name="parentId">父标识</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        Task<int> GenerateSortIdAsync(Guid applicationId, Guid? parentId);

        /// <summary>
        /// 获取模块列表
        /// </summary>
        /// <param name="applicationId">应用程序标识</param>
        /// <param name="roleIds">角色标识列表</param>
        /// <returns>Task&lt;List&lt;Module&gt;&gt;.</returns>
        Task<List<Module>> GetModulesAsync(Guid applicationId, List<Guid> roleIds);
    }
}