using Util.Datas.Ef.Core;
using GreatWall.Data.Pos.Systems;
using GreatWall.Data.Stores.Abstractions.Systems;

namespace GreatWall.Data.Stores.Implements.Systems{
    /// <summary>
    /// 资源存储器
    /// </summary>
    public class ResourcePoStore : StoreBase<ResourcePo>, IResourcePoStore {
        /// <summary>
        /// 初始化资源存储器
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public ResourcePoStore( IKissU.GreatWallUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}