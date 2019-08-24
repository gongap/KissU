using KissU.Data.Repositories.Base;
using KissU.Domain.Systems.Models;
using KissU.Domain.Systems.Repositories;
using Util.Datas.Ef.Core;

namespace KissU.Data.Repositories.Systems
{
    /// <summary>
    /// 语言国际化仓储
    /// </summary>
    public class LanguageRepository : MRepositoryBase<Language, LanguageDetail>, ILanguageRepository
    {
        /// <summary>
        /// 初始化语言国际化仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public LanguageRepository(IAdminUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}