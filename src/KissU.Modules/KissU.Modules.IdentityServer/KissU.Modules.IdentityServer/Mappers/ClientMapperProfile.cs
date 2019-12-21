// <copyright file="ClientMapperProfile.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using System.Collections.Generic;
using System.Security.Claims;
using AutoMapper;
using KissU.Modules.IdentityServer.Domain.Models;
using Client = KissU.Modules.IdentityServer.Domain.Models.Client;
using Ids4 = IdentityServer4.Models;

namespace KissU.Modules.IdentityServer.Mappers
{
    /// <summary>
    /// 应用程序AutoMapper映射配置
    /// </summary>
    public class ClientMapperProfile : Profile
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public ClientMapperProfile()
        {
            CreateMap<Client, Ids4.Client>()
                .ForMember(dest => dest.ProtocolType, opt => opt.Condition(srs => srs != null));

            CreateMap<ClientSecret, Ids4.Secret>(MemberList.Destination)
                .ForMember(dest => dest.Type, opt => opt.Condition(srs => srs != null));

            CreateMap<ClientClaim, Claim>(MemberList.None)
                .ConstructUsing(src => new Claim(src.Type, src.Value))
                .ReverseMap();

            CreateMap<Property, KeyValuePair<string, string>>()
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
        }
    }
}
