using GreatWall.Service.Dtos;
using GreatWall.Service.Queries;
using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using Util.Applications;

namespace GreatWall.Service.Abstractions {
    /// <summary>
    /// 声明服务
    /// </summary>
    [ServiceBundle("api/{Service}")]
    public interface IClaimService : ICrudService<ClaimDto, ClaimQuery> {
    }
}