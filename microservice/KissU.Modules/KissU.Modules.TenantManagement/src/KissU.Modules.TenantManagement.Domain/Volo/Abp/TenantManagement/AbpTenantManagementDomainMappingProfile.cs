using AutoMapper;
using Volo.Abp.Data;
using Volo.Abp.MultiTenancy;

namespace KissU.Modules.TenantManagement
{
    public class AbpTenantManagementDomainMappingProfile : Profile
    {
        public AbpTenantManagementDomainMappingProfile()
        {
            CreateMap<Tenant, TenantConfiguration>()
                .ForMember(ti => ti.ConnectionStrings, opts =>
                {
                    opts.MapFrom((tenant, ti) =>
                    {
                        var connStrings = new ConnectionStrings();

                        foreach (var connectionString in tenant.ConnectionStrings)
                        {
                            connStrings[connectionString.Name] = connectionString.Value;
                        }

                        return connStrings;
                    });
                });

            CreateMap<Tenant, TenantEto>();
        }
    }
}
