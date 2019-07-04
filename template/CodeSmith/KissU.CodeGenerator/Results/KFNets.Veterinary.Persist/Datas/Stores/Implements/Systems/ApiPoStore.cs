using Util.Datas.Ef.Core;
using KFNets.Veterinary.Data.Pos.Systems;
using KFNets.Veterinary.Data.Stores.Abstractions.Systems;

namespace KFNets.Veterinary.Data.Stores.Implements.Systems{
    /// <summary>
    /// Api资源存储器
    /// </summary>
    public class ApiPoStore : StoreBase<ApiPo>, IApiPoStore {
        /// <summary>
        /// 初始化Api资源存储器
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public ApiPoStore( IKFNetsUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}