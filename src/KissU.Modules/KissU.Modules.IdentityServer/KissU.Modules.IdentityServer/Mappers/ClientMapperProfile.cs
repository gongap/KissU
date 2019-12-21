// <copyright file="ClientMapperProfile.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using System.Collections.Generic;
using System.Security.Claims;
using AutoMapper;
using KissU.Modules.IdentityServer.Domain.Models;
using Ids4=IdentityServer4.Models;

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
        }
    }
}
