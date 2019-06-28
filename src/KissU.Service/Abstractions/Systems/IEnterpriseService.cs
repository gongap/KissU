using Util.Applications;
using KissU.Service.Dtos.Systems;
using KissU.Service.Queries.Systems;

namespace KissU.Service.Abstractions.Systems {
    /// <summary>
    /// 企业服务
    /// </summary>
    public interface IEnterpriseService : ICrudService<EnterpriseDto, EnterpriseQuery> {
    }
}