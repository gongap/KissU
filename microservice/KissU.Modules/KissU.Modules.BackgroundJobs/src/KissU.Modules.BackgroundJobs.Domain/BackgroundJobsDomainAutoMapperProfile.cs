using AutoMapper;
using Volo.Abp.AutoMapper;
using Volo.Abp.BackgroundJobs;

namespace KissU.Modules.BackgroundJobs.Domain
{
    public class BackgroundJobsDomainAutoMapperProfile : Profile
    {
        public BackgroundJobsDomainAutoMapperProfile()
        {
            CreateMap<BackgroundJobInfo, BackgroundJobRecord>()
                .ConstructUsing(x => new BackgroundJobRecord(x.Id))
                .Ignore(record => record.ConcurrencyStamp)
                .Ignore(record => record.ExtraProperties);

            CreateMap<BackgroundJobRecord, BackgroundJobInfo>();
        }
    }
}
