// <copyright file="ILanguageRepository.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using KissU.Util.Domains.Repositories;
using KissU.Modules.Theme.Domain.Models;

namespace KissU.Modules.Theme.Domain.Repositories
{
    /// <summary>
    /// 语言国际化仓储
    /// </summary>
    public interface ILanguageRepository : IRepository<Language>
    {
    }
}
