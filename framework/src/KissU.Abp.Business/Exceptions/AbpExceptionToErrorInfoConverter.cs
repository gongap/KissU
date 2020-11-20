using System;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using Volo.Abp.AspNetCore.ExceptionHandling;
using Volo.Abp.DependencyInjection;
using Volo.Abp.ExceptionHandling.Localization;
using Volo.Abp.Http;
using Volo.Abp.Localization.ExceptionHandling;

namespace KissU.Abp.Business.Exceptions
{
    [ExposeServices(typeof(IExceptionToErrorInfoConverter))]
    public class AbpExceptionToErrorInfoConverter : DefaultExceptionToErrorInfoConverter
    {
        public AbpExceptionToErrorInfoConverter(IOptions<AbpExceptionLocalizationOptions> localizationOptions, IStringLocalizerFactory stringLocalizerFactory, IStringLocalizer<AbpExceptionHandlingResource> abpUiStringLocalizer, IServiceProvider serviceProvider)
            : base(localizationOptions, stringLocalizerFactory, abpUiStringLocalizer, serviceProvider)
        {
        }

        protected override RemoteServiceErrorInfo CreateErrorInfoWithoutCode(Exception exception, bool includeSensitiveDetails)
        {
            return base.CreateErrorInfoWithoutCode(exception, includeSensitiveDetails);
        }
    }
}