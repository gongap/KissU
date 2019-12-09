// <copyright file="ILanguageRepository.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.Theme.Domain.Repositories
{
    using KissU.Modules.Theme.Domain.Models;
    using Util.Domains.Repositories;

    /// <summary>
    ///     语言国际化仓储
    /// </summary>
    public interface ILanguageRepository : IRepository<Language>
    {
    }
}
