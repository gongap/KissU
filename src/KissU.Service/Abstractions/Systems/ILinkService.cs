using Util.Applications;
using KissU.Service.Dtos.Systems;
using KissU.Service.Queries.Systems;

namespace KissU.Service.Abstractions.Systems {
    /// <summary>
    /// 链接服务
    /// </summary>
    public interface ILinkService : ICrudService<LinkDto, LinkQuery> {
    }
}