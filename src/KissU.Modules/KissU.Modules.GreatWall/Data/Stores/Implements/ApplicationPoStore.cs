using GreatWall.Data.Pos;
using GreatWall.Data.Stores.Abstractions;
using Util.Datas.Ef.Core;

namespace GreatWall.Data.Stores.Implements{
    /// <summary>
    /// 应用程序存储器
    /// </summary>
    public class ApplicationPoStore : StoreBase<ApplicationPo>, IApplicationPoStore {
        /// <summary>
        /// 初始化应用程序存储器
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public ApplicationPoStore( IGreatWallUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}