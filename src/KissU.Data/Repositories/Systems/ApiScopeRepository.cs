using KissU.Domain.Systems.Models;
using KissU.Domain.Systems.Repositories;
using Util.Datas.Ef.Core;

namespace KissU.Data.Repositories.Systems 
{
    /// <summary>
    /// Api许可范围仓储
    /// </summary>
    public class ApiScopeRepository : RepositoryBase<ApiScope>, IApiScopeRepository 
	{
        /// <summary>
        /// 初始化Api许可范围仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public ApiScopeRepository( IKissUUnitOfWork unitOfWork ) : base( unitOfWork ) 
		{
        }
    }
}