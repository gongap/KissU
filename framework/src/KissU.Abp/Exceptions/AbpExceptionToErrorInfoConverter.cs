using Localization.Resources.AbpUi;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Http;
using Volo.Abp.Localization.ExceptionHandling;

namespace Volo.Abp.AspNetCore.ExceptionHandling
{
    [ExposeServices(typeof(IExceptionToErrorInfoConverter))]
    public class AbpExceptionToErrorInfoConverter : DefaultExceptionToErrorInfoConverter
    {
        public AbpExceptionToErrorInfoConverter(IOptions<AbpExceptionLocalizationOptions> localizationOptions, IStringLocalizerFactory stringLocalizerFactory, IStringLocalizer<AbpUiResource> abpUiStringLocalizer, IServiceProvider serviceProvider)
            : base(localizationOptions, stringLocalizerFactory, abpUiStringLocalizer, serviceProvider)
        {
        }

        protected override RemoteServiceErrorInfo CreateErrorInfoWithoutCode(Exception exception)
        {
            return base.CreateErrorInfoWithoutCode(exception);
        }
    }
}