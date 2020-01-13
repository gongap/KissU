// <copyright file="MapperProfile.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using System.Collections.Generic;
using System.Security.Claims;
using AutoMapper;
using KissU.Modules.IdentityServer.Domain.Models;
using Ids4 = IdentityServer4.Models;

namespace KissU.Modules.IdentityServer.Application.Mappers
{
    /// <summary>
    /// 映射配置
    /// </summary>
    public class MapperProfile : Profile
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public MapperProfile()
        {
            CreateMap<ClientClaim, Claim>(MemberList.None)
                .ConstructUsing(src => new Claim(src.Type, src.Value))
                .ReverseMap();

            CreateMap<ClientGrantType, string>()
                .ConstructUsing(src => src.GrantType)
                .ReverseMap()
                .ForMember(dest => dest.GrantType, opt => opt.MapFrom(src => src));

            CreateMap<ClientRedirectUri, string>()
                .ConstructUsing(src => src.RedirectUri)
                .ReverseMap()
                .ForMember(dest => dest.RedirectUri, opt => opt.MapFrom(src => src));

            CreateMap<ClientPostLogoutRedirectUri, string>()
                .ConstructUsing(src => src.PostLogoutRedirectUri)
                .ReverseMap()
                .ForMember(dest => dest.PostLogoutRedirectUri, opt => opt.MapFrom(src => src));

            CreateMap<ClientScope, string>()
                .ConstructUsing(src => src.Scope)
                .ReverseMap()
                .ForMember(dest => dest.Scope, opt => opt.MapFrom(src => src));

            CreateMap<ClientIdPRestriction, string>()
                .ConstructUsing(src => src.Provider)
                .ReverseMap()
                .ForMember(dest => dest.Provider, opt => opt.MapFrom(src => src));

            CreateMap<ClientCorsOrigin, string>()
                .ConstructUsing(src => src.Origin)
                .ReverseMap()
                .ForMember(dest => dest.Origin, opt => opt.MapFrom(src => src));

            CreateMap<Property, KeyValuePair<string, string>>()
                .ReverseMap();

            CreateMap<UserClaim<IdentityResource>, string>()
                .ConstructUsing(x => x.Type)
                .ReverseMap()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src));

            CreateMap<UserClaim<ApiResource>, string>()
                .ConstructUsing(x => x.Type)
                .ReverseMap()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src));

            CreateMap<UserClaim<ApiScope>, string>()
                .ConstructUsing(x => x.Type)
                .ReverseMap()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src));

            CreateMap<Client, Ids4.Client>()
                .ForMember(dest => dest.ProtocolType, opt => opt.Condition(srs => srs != null));

            CreateMap<ClientSecret, Ids4.Secret>(MemberList.Destination)
                .ForMember(dest => dest.Type, opt => opt.Condition(srs => srs != null));

            CreateMap<ApiSecret, Ids4.Secret>(MemberList.Destination)
                .ForMember(dest => dest.Type, opt => opt.Condition(srs => srs != null));

            CreateMap<ApiScope, Ids4.Scope>(MemberList.Destination)
                .ConstructUsing(src => new Ids4.Scope())
                .ReverseMap();

            CreateMap<IdentityResource, Ids4.IdentityResource>()
                .ReverseMap();

            CreateMap<ApiResource, Ids4.ApiResource>()
                .ReverseMap();
        }
    }
}
