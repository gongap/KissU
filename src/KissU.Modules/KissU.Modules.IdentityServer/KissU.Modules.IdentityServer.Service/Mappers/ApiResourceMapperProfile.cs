// <copyright file="ApiResourceMapperProfile.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using AutoMapper;
using KissU.Modules.IdentityServer.Domain.Models;
using KissU.Modules.IdentityServer.Service.Contracts.Dtos;
using KissU.Modules.IdentityServer.Service.Contracts.Dtos.Requests;

namespace KissU.Modules.IdentityServer.Service.Mappers
{
    /// <summary>
    /// Api资源AutoMapper映射配置
    /// </summary>
    public class ApiResourceMapperProfile : Profile
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public ApiResourceMapperProfile()
        {
            CreateMap<ApiScope, ApiResourceScopeDto>(MemberList.Destination)
                .ForMember(x => x.ApiResourceId, opt => opt.MapFrom(x => x.ApiResource.Id));
            CreateMap<ApiResourceScopeDto, ApiScope>(MemberList.Source)
                .ForMember(x => x.ApiResource, opts => opts.MapFrom(src => new ApiResource(src.ApiResourceId)));

            CreateMap<ApiScope, ApiResourceScopeCreateRequest>(MemberList.Destination)
                .ForMember(x => x.ApiResourceId, opt => opt.MapFrom(x => x.ApiResource.Id));
            CreateMap<ApiResourceScopeCreateRequest, ApiScope>(MemberList.Source)
                .ForMember(x => x.ApiResource, opts => opts.MapFrom(src => new ApiResource(src.ApiResourceId)));

            CreateMap<ApiSecret, ApiResourceSecretDto>(MemberList.Destination)
                .ForMember(x => x.ApiResourceId, opt => opt.MapFrom(x => x.ApiResource.Id));
            CreateMap<ApiResourceSecretDto, ApiSecret>(MemberList.Source)
                .ForMember(x => x.ApiResource, opts => opts.MapFrom(src => new ApiResource(src.ApiResourceId)));

            CreateMap<ApiSecret, ApiResourceSecretCreateRequest>(MemberList.Destination)
                .ForMember(x => x.ApiResourceId, opt => opt.MapFrom(x => x.ApiResource.Id));
            CreateMap<ApiResourceSecretCreateRequest, ApiSecret>(MemberList.Source)
                .ForMember(x => x.ApiResource, opts => opts.MapFrom(src => new ApiResource(src.ApiResourceId)));
        }
    }
}
