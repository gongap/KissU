using Util.Datas.Ef.Core;
using KissU.Data.Pos.Systems;
using KissU.Data.Stores.Abstractions.Systems;

namespace KissU.Data.Stores.Implements.Systems
{
    /// <summary>
    /// 角色存储器
    /// </summary>
    public class RolePoStore : StoreBase<RolePo>, IRolePoStore 
	{
        /// <summary>
        /// 初始化角色存储器
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public RolePoStore( IKissUUnitOfWork unitOfWork ) : base( unitOfWork ) 
		{
        }
    }
}