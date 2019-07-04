using Util.Datas.Ef.Core;
using KissU.GreatWall.Data.Pos.Systems;
using KissU.GreatWall.Data.Stores.Abstractions.Systems;

namespace KissU.GreatWall.Data.Stores.Implements.Systems{
    /// <summary>
    /// Api许可范围存储器
    /// </summary>
    public class ApiScopePoStore : StoreBase<ApiScopePo>, IApiScopePoStore {
        /// <summary>
        /// 初始化Api许可范围存储器
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public ApiScopePoStore( IKissUUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}