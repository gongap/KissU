using Util;
using Util.Maps;
using Util.Domains.Repositories;
using Util.Datas.Queries;
using Util.Applications;
using KissU.Data;
using KissU.Domain.Systems.Models;
using KissU.Domain.Systems.Repositories;
using KissU.Service.Dtos.Systems;
using KissU.Service.Queries.Systems;
using KissU.Service.Abstractions.Systems;

namespace KissU.Service.Implements.Systems {
    /// <summary>
    /// 链接服务
    /// </summary>
    public class LinkService : CrudServiceBase<Link, LinkDto, LinkQuery>, ILinkService {
        /// <summary>
        /// 初始化链接服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="linkRepository">链接仓储</param>
        public LinkService( IKissUUnitOfWork unitOfWork, ILinkRepository linkRepository )
            : base( unitOfWork, linkRepository ) {
            LinkRepository = linkRepository;
        }
        
        /// <summary>
        /// 链接仓储
        /// </summary>
        public ILinkRepository LinkRepository { get; set; }
        
        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">查询参数</param>
        protected override IQueryBase<Link> CreateQuery( LinkQuery param ) {
            return new Query<Link>( param );
        }
    }
}