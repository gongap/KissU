using KissU.Modules.Admin.Data.Repositories.Base;
using KissU.Modules.Admin.Domain.Models;
using KissU.Modules.Admin.Domain.Repositories;

namespace KissU.Modules.Admin.Data.Repositories
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