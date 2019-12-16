// <copyright file="LanguageService.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissU.Modules.Theme.Data;
using KissU.Modules.Theme.Domain.Models;
using KissU.Modules.Theme.Domain.Repositories;
using KissU.Modules.Theme.Service.Contracts.Abstractions;
using KissU.Modules.Theme.Service.Contracts.Dtos;
using KissU.Modules.Theme.Service.Contracts.Queries;
using KissU.Modules.Theme.Service.Extensions;
using KissU.Util.Applications;
using KissU.Util.Datas.Queries;
using KissU.Util.Domains.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KissU.Modules.Theme.Service.Implements
{
    /// <summary>
    /// 语言国际化服务
    /// </summary>
    public class LanguageService : CrudServiceBase<Language, LanguageDto, LanguageQuery>, ILanguageService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LanguageService"/> class.
        /// 初始化语言国际化服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="languageRepository">语言国际化仓储</param>
        public LanguageService(IThemeUnitOfWork unitOfWork, ILanguageRepository languageRepository)
            : base(unitOfWork, languageRepository)
        {
            UnitOfWork = unitOfWork;
            LanguageRepository = languageRepository;
        }

        /// <summary>
        /// 工作单元
        /// </summary>
        public IThemeUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// 语言国际化仓储
        /// </summary>
        public ILanguageRepository LanguageRepository { get; set; }

        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">查询参数</param>
        /// <returns>结果</returns>
        protected override IQueryBase<Language> CreateQuery(LanguageQuery param)
        {
            return new Query<Language>(param);
        }

        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>结果</returns>
        protected override LanguageDto ToDto(Language entity)
        {
            return entity.ToDto();
        }

        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        /// <returns>结果</returns>
        protected override Language ToEntity(LanguageDto dto)
        {
            return dto.ToEntity();
        }

        /// <summary>
        /// 获取语言国际化数据
        /// </summary>
        /// <param name="lang">语言编码</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task<Dictionary<string, string>> GetLangDataAsync(string lang)
        {
            var language = await LanguageRepository.Find(x => x.Code == lang).Include(x => x.Details)
                .SingleOrDefaultAsync();
            if (language != null && language.Details?.Count > 0)
            {
                return language.Details.ToDictionary(k => k.Key, v => v.Value);
            }

            return null;
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="request">创建参数</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public override async Task<string> CreateAsync(LanguageDto request)
        {
            var result = await base.CreateAsync(request);
            await UnitOfWork.CommitAsync();

            return result;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="request">修改参数</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public override async Task UpdateAsync(LanguageDto request)
        {
            await base.UpdateAsync(request);
            await UnitOfWork.CommitAsync();
        }
    }
}
