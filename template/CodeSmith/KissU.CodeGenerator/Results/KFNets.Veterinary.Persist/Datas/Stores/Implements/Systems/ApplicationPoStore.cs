using Util.Datas.Ef.Core;
using KFNets.Veterinary.Data.Pos.Systems;
using KFNets.Veterinary.Data.Stores.Abstractions.Systems;

namespace KFNets.Veterinary.Data.Stores.Implements.Systems{
    /// <summary>
    /// 应用程序存储器
    /// </summary>
    public class ApplicationPoStore : StoreBase<ApplicationPo>, IApplicationPoStore {
        /// <summary>
        /// 初始化应用程序存储器
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public ApplicationPoStore( IKFNetsUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}