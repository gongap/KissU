using KissU.Domain.Systems.Models;
using KissU.Domain.Systems.Repositories;
using Util.Datas.Ef.Core;

namespace KissU.Data.Repositories.Systems 
{
    /// <summary>
    /// 菜单仓储
    /// </summary>
    public class MenuRepository : TreeRepositoryBase<Menu>, IMenuRepository 
	{
        /// <summary>
        /// 初始化菜单仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public MenuRepository( IKissUUnitOfWork unitOfWork ) : base( unitOfWork ) 
		{
        }
    }
}