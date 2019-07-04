using Util.Datas.Ef.Core;
using KissU.GreatWall.Data.Pos.Systems;
using KissU.GreatWall.Data.Stores.Abstractions.Systems;

namespace KissU.GreatWall.Data.Stores.Implements.Systems{
    /// <summary>
    /// Api资源存储器
    /// </summary>
    public class ApiPoStore : StoreBase<ApiPo>, IApiPoStore {
        /// <summary>
        /// 初始化Api资源存储器
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public ApiPoStore( IKissUUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}