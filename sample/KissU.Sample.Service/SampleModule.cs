using Volo.Abp.Modularity;
using KissU.Modularity;

namespace KissU.Msm.Sample.Service;

[DependsOn( )]
public class SampleModule : AbpModule, IBusinessModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
    }
}
