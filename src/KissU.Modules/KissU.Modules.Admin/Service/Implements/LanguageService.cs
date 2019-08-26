using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissU.IModuleServices.Admin.Abstractions;
using KissU.IModuleServices.Admin.Dtos;
using KissU.IModuleServices.Admin.Queries;
using KissU.Modules.Admin.Data;
using KissU.Modules.Admin.Domain.Models;
using KissU.Modules.Admin.Domain.Repositories;
using KissU.Modules.Admin.Service.Extensions;
using Microsoft.EntityFrameworkCore;
using Util.Applications;
using Util.Datas.Queries;
using Util.Domains.Repositories;

namespace KissU.Modules.Admin.Service.Implements
{
    /// <summary>
    /// 语言国际化服务
    /// </summary>
    public class LanguageService : CrudServiceBase<Language, LanguageDto, LanguageQuery>, ILanguageService
    {
        /// <summary>
        /// 初始化语言国际化服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="languageRepository">语言国际化仓储</param>
        public LanguageService(IAdminUnitOfWork unitOfWork, ILanguageRepository languageRepository)
            : base(unitOfWork, languageRepository)
        {
            LanguageRepository = languageRepository;
        }

        /// <summary>
        /// 语言国际化仓储
        /// </summary>
        public ILanguageRepository LanguageRepository { get; set; }

        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">查询参数</param>
        protected override IQueryBase<Language> CreateQuery(LanguageQuery param)
        {
            return new Query<Language>(param);
        }

        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        /// <param name="entity">实体</param>
        protected override LanguageDto ToDto(Language entity)
        {
            return entity.ToDto();
        }

        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        protected override Language ToEntity(LanguageDto dto)
        {
            return dto.ToEntity();
        }

        /// <summary>通过编码获取</summary>
        /// <param name="code">编码</param>
        public async Task<Dictionary<string, string>> GetByCodeAsync(string code)
        {
            var language = await LanguageRepository.Find(x => x.Code == code).Include(x => x.Details)
                .SingleOrDefaultAsync();
            if (language != null && language.Details?.Count > 0)
            {
                return language.Details.ToDictionary(k => k.Key, v => v.Value);
            }

            return null;
        }
    }
}