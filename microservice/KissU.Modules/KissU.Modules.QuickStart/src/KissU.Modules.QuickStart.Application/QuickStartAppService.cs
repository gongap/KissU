using KissU.Modules.QuickStart.Localization;
using Volo.Abp.Application.Services;

namespace KissU.Modules.QuickStart
{
    public abstract class QuickStartAppService : ApplicationService
    {
        protected QuickStartAppService()
        {
            LocalizationResource = typeof(QuickStartResource);
            ObjectMapperContext = typeof(QuickStartApplicationModule);
        }
    }
}
