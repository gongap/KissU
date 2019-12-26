using System;
using System.Threading.Tasks;
using KissU.Modules.GreatWall.Application.Dtos;
using KissU.Modules.GreatWall.Service.Contracts;

namespace KissU.Modules.GreatWall.Service
{
    /// <summary>
    /// Api资源服务
    /// </summary>
    public class ApiResourceService : IApiResourceService
    {
        /// <summary>
        /// 创建Api资源
        /// </summary>
        /// <param name="dto">Api资源参数</param>
        public async Task<Guid> CreateAsync(ApiResourceDto dto)
        {
            return default;
        }

        /// <summary>
        /// 修改Api资源
        /// </summary>
        /// <param name="dto">Api资源参数</param>
        public async Task UpdateAsync(ApiResourceDto dto)
        {
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        public async Task DeleteAsync(string ids)
        {
        }
    }
}