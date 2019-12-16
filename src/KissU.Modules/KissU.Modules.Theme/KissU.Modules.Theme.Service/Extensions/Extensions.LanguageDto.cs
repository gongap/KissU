// <copyright file="Extensions.LanguageDto.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using KissU.Modules.Theme.Domain.Models;
using KissU.Modules.Theme.Service.Contracts.Dtos;
using KissU.Util;
using KissU.Util.Maps;

namespace KissU.Modules.Theme.Service.Extensions
{
    /// <summary>
    /// 语言国际化参数扩展
    /// </summary>
    public static class LanguageDtoExtension
    {
        /// <summary>
        /// 转换为语言国际化实体
        /// </summary>
        /// <param name="dto">语言国际化参数</param>
        /// <returns>结果</returns>
        public static Language ToEntity(this LanguageDto dto)
        {
            if (dto == null)
            {
                return new Language();
            }

            var entity = new Language(dto.Id.ToGuid())
            {
                Code = dto.Code,
                Text = dto.Text,
                Abbr = dto.Abbr,
                IsEnabled = dto.IsEnabled.SafeValue(),
            };
            if (dto.Details?.Count > 0)
            {
                dto.Details.ForEach(x => entity.AddDetail(x.MapTo<LanguageDetail>()));
            }

            return entity;
        }

        /// <summary>
        /// 转换为语言国际化参数
        /// </summary>
        /// <param name="entity">语言国际化实体</param>
        /// <returns>结果</returns>
        public static LanguageDto ToDto(this Language entity)
        {
            if (entity == null)
            {
                return new LanguageDto();
            }

            return new LanguageDto
            {
                Id = entity.Id.ToString(),
                Code = entity.Code,
                Text = entity.Text,
                Abbr = entity.Abbr,
                IsEnabled = entity.IsEnabled,
                Details = entity.Details?.MapToList<LanguageDetailDto>(),
                Version = entity.Version
            };
        }
    }
}
