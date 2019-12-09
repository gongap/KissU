// <copyright file="ApiResourceMapperProfile.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.IdentityServer.Service.Mappers
{
    using AutoMapper;
    using KissU.Modules.IdentityServer.Domain.Models.ApiResourceAggregate;
    using KissU.Modules.IdentityServer.Service.Contracts.Dtos;
    using KissU.Modules.IdentityServer.Service.Contracts.Dtos.Requests;
    using Ids4 = IdentityServer4.Models;

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
            CreateMap<ApiResourceScope, ApiResourceScopeDto>(MemberList.Destination)
                .ForMember(x => x.ApiResourceId, opt => opt.MapFrom(x => x.ApiResource.Id));
            CreateMap<ApiResourceScopeDto, ApiResourceScope>(MemberList.Source)
                .ForMember(x => x.ApiResource, opts => opts.MapFrom(src => new ApiResource(src.ApiResourceId)));

            CreateMap<ApiResourceScope, ApiResourceScopeCreateRequest>(MemberList.Destination)
                .ForMember(x => x.ApiResourceId, opt => opt.MapFrom(x => x.ApiResource.Id));
            CreateMap<ApiResourceScopeCreateRequest, ApiResourceScope>(MemberList.Source)
                .ForMember(x => x.ApiResource, opts => opts.MapFrom(src => new ApiResource(src.ApiResourceId)));

            CreateMap<ApiResourceSecret, ApiResourceSecretDto>(MemberList.Destination)
                .ForMember(x => x.ApiResourceId, opt => opt.MapFrom(x => x.ApiResource.Id));
            CreateMap<ApiResourceSecretDto, ApiResourceSecret>(MemberList.Source)
                .ForMember(x => x.ApiResource, opts => opts.MapFrom(src => new ApiResource(src.ApiResourceId)));

            CreateMap<ApiResourceSecret, ApiResourceSecretCreateRequest>(MemberList.Destination)
                .ForMember(x => x.ApiResourceId, opt => opt.MapFrom(x => x.ApiResource.Id));
            CreateMap<ApiResourceSecretCreateRequest, ApiResourceSecret>(MemberList.Source)
                .ForMember(x => x.ApiResource, opts => opts.MapFrom(src => new ApiResource(src.ApiResourceId)));

            CreateMap<ApiResourceSecret, Ids4.Secret>(MemberList.Destination)
                .ForMember(dest => dest.Type, opt => opt.Condition(srs => srs != null));
        }
    }
}
