using Util.Datas.Ef.Core;
using KissU.Data.Pos.Systems;
using KissU.Data.Stores.Abstractions.Systems;

namespace KissU.Data.Stores.Implements.Systems{
    /// <summary>
    /// 应用程序存储器
    /// </summary>
    public class ApplicationPoStore : StoreBase<ApplicationPo>, IApplicationPoStore {
        /// <summary>
        /// 初始化应用程序存储器
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public ApplicationPoStore( IKissUUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}