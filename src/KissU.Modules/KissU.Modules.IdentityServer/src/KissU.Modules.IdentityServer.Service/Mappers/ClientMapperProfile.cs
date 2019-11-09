using System.Collections.Generic;
using System.Security.Claims;
using AutoMapper;
using KissU.Modules.IdentityServer.Domain.Models.ClientAggregate;
using Client = KissU.Modules.IdentityServer.Domain.Models.ClientAggregate.Client;
using Ids4 = IdentityServer4.Models;

namespace KissU.Modules.IdentityServer.Service.Mappers
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
                .ForMember(dest => dest.ProtocolType, opt => opt.Condition(srs => srs != null))
                .ForMember(dest => dest.ClientId, opt => opt.MapFrom(srs => srs.ClientCode));

            CreateMap<ClientSecret, Ids4.Secret>(MemberList.Destination)
                .ForMember(dest => dest.Type, opt => opt.Condition(srs => srs != null));

            CreateMap<ClientProperty, KeyValuePair<string, string>>()
                .ReverseMap();

            CreateMap<ClientClaim, Claim>(MemberList.None)
                 .ConstructUsing(src => new Claim(src.Type, src.Value))
                .ReverseMap();
        }
    }
}