using GreatWall.Service.Dtos;
using GreatWall.Service.Queries;
using Util.Applications;

namespace GreatWall.Service.Abstractions {
    /// <summary>
    /// 声明服务
    /// </summary>
    public interface IClaimService : ICrudService<ClaimDto, ClaimQuery> {
    }
}