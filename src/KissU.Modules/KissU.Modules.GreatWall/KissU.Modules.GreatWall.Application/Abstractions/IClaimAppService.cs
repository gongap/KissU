using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Modules.GreatWall.Application.Dtos;
using KissU.Modules.GreatWall.Application.Queries;
using KissU.Util.Applications;

namespace KissU.Modules.GreatWall.Application.Abstractions
{
    /// <summary>
    /// 声明服务
    /// </summary>
    public interface IClaimAppService : ICrudService<ClaimDto, ClaimQuery>
    {
        /// <summary>
        /// 获取已启用的声明列表
        /// </summary>
        Task<List<ClaimDto>> GetEnabledClaimsAsync();
    }
}