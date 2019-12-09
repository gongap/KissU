// <copyright file="LanguageRepository.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.Theme.Data.Repositories
{
    using KissU.Modules.Theme.Data.Repositories.Base;
    using KissU.Modules.Theme.Domain.Models;
    using KissU.Modules.Theme.Domain.Repositories;

    /// <summary>
    /// 语言国际化仓储
    /// </summary>
    public class LanguageRepository : MRepositoryBase<Language, LanguageDetail>, ILanguageRepository
    {
        /// <summary>
        /// 初始化语言国际化仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public LanguageRepository(IThemeUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
