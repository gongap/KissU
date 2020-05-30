using AutoMapper;

namespace KissU.Modules.TenantManagement
{
    public class AbpTenantManagementApplicationAutoMapperProfile : Profile
    {
        public AbpTenantManagementApplicationAutoMapperProfile()
        {
            CreateMap<Tenant, TenantDto>()
                .MapExtraProperties();
        }
    }
}