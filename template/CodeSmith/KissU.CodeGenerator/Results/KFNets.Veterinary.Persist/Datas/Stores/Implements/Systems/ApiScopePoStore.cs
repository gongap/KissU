using Util.Datas.Ef.Core;
using KFNets.Veterinary.Data.Pos.Systems;
using KFNets.Veterinary.Data.Stores.Abstractions.Systems;

namespace KFNets.Veterinary.Data.Stores.Implements.Systems{
    /// <summary>
    /// Api许可范围存储器
    /// </summary>
    public class ApiScopePoStore : StoreBase<ApiScopePo>, IApiScopePoStore {
        /// <summary>
        /// 初始化Api许可范围存储器
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public ApiScopePoStore( IKFNetsUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}