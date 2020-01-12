using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissU.Modules.GreatWall.Application.Abstractions;
using KissU.Modules.GreatWall.Application.Dtos;
using KissU.Modules.GreatWall.Application.Queries;
using KissU.Modules.GreatWall.Domain.Models;
using KissU.Modules.GreatWall.Domain.Repositories;
using KissU.Modules.GreatWall.Domain.UnitOfWorks;
using KissU.Util.Applications;
using KissU.Util.Datas.Queries;
using KissU.Util.Domains.Repositories;

namespace KissU.Modules.GreatWall.Application.Implements
{
    /// <summary>
    /// 声明服务
    /// </summary>
    public class ClaimAppService : CrudServiceBase<Claim, ClaimDto, ClaimQuery>, IClaimAppService
    {
        /// <summary>
        /// 初始化声明服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="claimRepository">声明仓储</param>
        public ClaimAppService(IGreatWallUnitOfWork unitOfWork, IClaimRepository claimRepository)
            : base(unitOfWork, claimRepository)
        {
            ClaimRepository = claimRepository;
        }

        /// <summary>
        /// 声明仓储
        /// </summary>
        public IClaimRepository ClaimRepository { get; set; }

        /// <summary>
        /// 获取已启用的声明列表
        /// </summary>
        public async Task<List<ClaimDto>> GetEnabledClaimsAsync()
        {
            var entities = await ClaimRepository.FindAllAsync(t => t.Enabled);
            return entities.Select(ToDto).ToList();
        }

        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">查询参数</param>
        protected override IQueryBase<Claim> CreateQuery(ClaimQuery param)
        {
            return new Query<Claim>(param)
                .WhereIfNotEmpty(t => t.Name.Contains(param.Name))
                .WhereIfNotEmpty(t => t.Remark.Contains(param.Remark));
        }
    }
}