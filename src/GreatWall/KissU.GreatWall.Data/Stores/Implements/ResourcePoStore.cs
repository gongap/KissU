using KissU.GreatWall.Data.Pos;
using KissU.GreatWall.Data.Stores.Abstractions;
using Util.Datas.Ef.Core;

namespace KissU.GreatWall.Data.Stores.Implements{
    /// <summary>
    /// 资源存储器
    /// </summary>
    public class ResourcePoStore : StoreBase<ResourcePo>, IResourcePoStore {
        /// <summary>
        /// 初始化资源存储器
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public ResourcePoStore( IGreatWallUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}