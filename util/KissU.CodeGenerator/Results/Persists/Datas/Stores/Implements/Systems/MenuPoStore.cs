using Util.Datas.Ef.Core;
using KissU.Data.Pos.Systems;
using KissU.Data.Stores.Abstractions.Systems;

namespace KissU.Data.Stores.Implements.Systems{
    /// <summary>
    /// 存储器
    /// </summary>
    public class MenuPoStore : StoreBase<MenuPo>, IMenuPoStore {
        /// <summary>
        /// 初始化存储器
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public MenuPoStore( IKissUUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}