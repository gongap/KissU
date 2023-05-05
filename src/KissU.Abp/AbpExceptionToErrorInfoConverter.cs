using Volo.Abp.AspNetCore.ExceptionHandling;
using Volo.Abp.ExceptionHandling.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using KissU.Exceptions;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Text;

namespace KissU.Abp
{
    public class AbpExceptionToErrorInfoConverter : DefaultExceptionToErrorInfoConverter, Exceptions.Handling.IExceptionToErrorInfoConverter
    {

        public AbpExceptionToErrorInfoConverter(IOptions<AbpExceptionLocalizationOptions> localizationOptions, IStringLocalizerFactory stringLocalizerFactory, IStringLocalizer<AbpExceptionHandlingResource> stringLocalizer, IServiceProvider serviceProvider) : base(localizationOptions, stringLocalizerFactory, stringLocalizer, serviceProvider)
        {
        }

        public  RemoteServiceErrorInfo Convert(Exception exception, bool includeSensitiveDetails)
        {
            var errorInfo = base.Convert(exception, false);
            if (includeSensitiveDetails)
            {
                var detailBuilder = new StringBuilder();
                AddExceptionToDetails(exception, detailBuilder, includeSensitiveDetails);
                errorInfo.Details = detailBuilder.ToString();
            }

            return new RemoteServiceErrorInfo(errorInfo.Message, errorInfo.Details, errorInfo.Code)
            {
                ValidationErrors = errorInfo.ValidationErrors?.Select(x => new RemoteServiceValidationErrorInfo(x.Message, x.Members)).ToArray(),
            };
        }
    }
}
